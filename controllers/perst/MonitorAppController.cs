using Newtonsoft.Json;
using oodb_project.models;
using WebSocketSharp;

namespace oodb_project.controllers.perst
{
    public class MonitorAppController
    {
        /// <summary>
        /// Обновление объекта MonitorApp
        /// </summary>
        public Func<MonitorAppModel, IResult> update = (data) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/monitor-app"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<MonitorAppModel>(e.Data);

                    if (((MonitorAppModel?)outputData)?.Id == null)
                    {
                        outputData = JsonConvert.DeserializeObject<MessageModel>(e.Data);
                    }

                    flag = true;
                };

                // Подключение по WebSocket-соединению к приложению
                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(
                    new HttpModel(
                        "/update",
                        JsonConvert.SerializeObject(data)
                    )
                ));

                // Бесконечный цикл для создания задержки обработки сообщения
                while (!flag)
                {
                    // bug(): если убрать Console.WriteLine бесконечный цикл будет длится вечно
                    Console.WriteLine(flag);
                }

            }

            return Results.Json(outputData);
        };

        /// <summary>
        /// Создание объекта MonitorAppModel
        /// </summary>
        public Func<AdminModel, IResult> create = (data) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/monitor-app"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<MonitorAppModel>(e.Data);

                    if (((MonitorAppModel?)outputData)?.Id == null)
                    {
                        outputData = JsonConvert.DeserializeObject<MessageModel>(e.Data);
                    }

                    flag = true;
                };

                // Подключение по WebSocket-соединению к приложению
                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(
                    new HttpModel(
                        "/save",
                        JsonConvert.SerializeObject(data)
                    )
                ));

                // Бесконечный цикл для создания задержки обработки сообщения
                while (!flag)
                {
                    // bug(): если убрать Console.WriteLine бесконечный цикл будет длится вечно
                    Console.WriteLine(flag);
                }

            }

            return Results.Json(outputData);
        };

        /// <summary>
        /// Получение всех объектов MonitorAppModel
        /// </summary>
        public Func<IResult> getAll = () =>
        {
            var flag = false;
            MonitorAppModel[]? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/monitor-app"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<MonitorAppModel[]>(e.Data);
                    flag = true;
                };

                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(new HttpModel("/get/all", null)));

                while (!flag)
                {
                    Console.WriteLine(flag);
                }

            }

            return Results.Json(outputData);
        };

        /// <summary>
        /// Получение конкретного объекта MonitorAppModel
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/monitor-app"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<MonitorAppModel>(e.Data);

                    if (((MonitorAppModel?)outputData)?.Id == null)
                    {
                        outputData = JsonConvert.DeserializeObject<MessageModel>(e.Data);
                    }

                    flag = true;
                };

                // Подключение по WebSocket-соединению к приложению
                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(
                    new HttpModel(
                        "/get",
                        id
                    )
                ));

                // Бесконечный цикл для создания задержки обработки сообщения
                while (!flag)
                {
                    // bug(): если убрать Console.WriteLine бесконечный цикл будет длится вечно
                    Console.WriteLine(flag);
                }

            }

            return Results.Json(outputData);
        };

        /// <summary>
        /// Удаление объекта MonitorAppModel
        /// </summary>
        public Func<string, IResult> delete = (id) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/monitor-app"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<MonitorAppModel>(e.Data);

                    if (((MonitorAppModel?)outputData)?.Id == null)
                    {
                        outputData = JsonConvert.DeserializeObject<MessageModel>(e.Data);
                    }

                    flag = true;
                };

                // Подключение по WebSocket-соединению к приложению
                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(
                    new HttpModel(
                        "/delete",
                        id
                    )
                ));

                // Бесконечный цикл для создания задержки обработки сообщения
                while (!flag)
                {
                    // bug(): если убрать Console.WriteLine бесконечный цикл будет длится вечно
                    Console.WriteLine(flag);
                }
            }

            return Results.Json(outputData);
        };
    }
}
