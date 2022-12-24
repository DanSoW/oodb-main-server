/* Импорты */
using Db4objects.Db4o;
using Newtonsoft.Json;
using oodb_project.controllers.db4o;
using oodb_project.controllers.perst;
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

/* Инициализация маршрутов для работы с ООДБ perst */
var initPerstController = new InitPerstController(app);
initPerstController.InitRoutes();

/* Запуск серверного приложения */
app.Run();

/* Закрытие соединений с базой данных */
dbDb4o.Close();
