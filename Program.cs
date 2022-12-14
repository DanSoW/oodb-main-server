/* Импорты */
using Db4objects.Db4o;
using Newtonsoft.Json;
using oodb_project.controllers.db4o;
using oodb_project.data;
using oodb_project.models;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using WebSocketSharp;
using WebSocketSharp.Server;

/* Создание экземпляра класса WebApplicationBuilder для конфигурирования веб-приложения */
var builder = WebApplication.CreateBuilder(args);

/* Сборка веб-приложения */
var app = builder.Build();

/* Конфигурирование статических путей к файлам */
app.UseDefaultFiles();
app.UseStaticFiles();

if (File.Exists("db4o.yap"))
{
    File.Delete("db4o.yap");
}

/* Конфигурирование ООБД (db4o) */
IObjectContainer dbDb4o = Db4oEmbedded.OpenFile(Db4oEmbedded.NewConfiguration(), "db4o.yap");

/* Заполнение ООБД тестовыми данными */
var mockData = new MockData(dbDb4o);
mockData.generateData();

/* Инициализация маршрутов для работы с ООБД db4o */
var initDb4oController = new InitDb4oController(app, dbDb4o);
initDb4oController.InitRoutes();

object ByteArrayToObject(byte[] arrBytes)
{
    MemoryStream memStream = new MemoryStream();
    BinaryFormatter binForm = new BinaryFormatter();
    memStream.Write(arrBytes, 0, arrBytes.Length);
    memStream.Seek(0, SeekOrigin.Begin);
#pragma warning disable SYSLIB0011 
    var obj = binForm.Deserialize(memStream);
#pragma warning restore SYSLIB0011

    return obj;
}

using (var ws = new WebSocket("ws://127.0.0.1/Laputa"))
{
    // Добавление обработчика на конкретное сообщение
    ws.OnMessage += (sender, e) =>
    {
        var admin = JsonConvert.DeserializeObject<AdminModel>(e.Data);

        if(admin != null)
        {
            Console.WriteLine(admin.Id);
        }
    };
    
    // Подключение по WebSocket-соединению к приложению
    ws.Connect();

    // Отправка данных
    ws.Send("BALUS");

    Console.ReadKey();
}

/* Запуск серверного приложения */
app.Run();

/* Закрытие соединений с базой данных */
dbDb4o.Close();
