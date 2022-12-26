using Newtonsoft.Json;
using oodb_project.models;
using WebSocketSharp;

namespace oodb_project.controllers.perst
{
    public class HostController
    {
        /// <summary>
        /// Обновление объекта HostModel
        /// </summary>
        public Func<HostModel, IResult> update = (data) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostModel>(e.Data);

                    if (((HostModel?)outputData)?.Id == null)
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
        /// Создание объекта AdminModel
        /// </summary>
        public Func<HostModel, IResult> create = (data) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostModel>(e.Data);

                    if (((HostModel?)outputData)?.Id == null)
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
        /// Получение всех объектов HostModel
        /// </summary>
        public Func<IResult> getAll = () =>
        {
            var flag = false;
            HostModel[]? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostModel[]>(e.Data);
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
        /// Получение конкретного объекта AdminModel
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            var flag = false;
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostModel>(e.Data);

                    if (((HostModel?)outputData)?.Id == null)
                    {
                        outputData = JsonConvert.DeserializeObject<MessageModel>(e.Data);
                    }

                    flag = true;
                };

                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(
                    new HttpModel(
                        "/get",
                        id
                    )
                ));

                while (!flag)
                {
                    Console.WriteLine(flag);
                }
            }

            return Results.Json(outputData);
        };

        /// <summary>
        /// Удаление объекта AdminModel
        /// </summary>
        public Func<string, IResult> delete = (id) =>
        {
            var flag = false;
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostModel>(e.Data);

                    if (((HostModel?)outputData)?.Id == null)
                    {
                        outputData = JsonConvert.DeserializeObject<MessageModel>(e.Data);
                    }

                    flag = true;
                };

                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(
                    new HttpModel(
                        "/delete",
                        id
                    )
                ));

                while (!flag)
                {
                    Console.WriteLine(flag);
                }

            }

            return Results.Json(outputData);
        };
    }
}
