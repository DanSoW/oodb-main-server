using Newtonsoft.Json;
using oodb_project.models;
using WebSocketSharp;

namespace oodb_project.controllers.perst
{
    public class HostServiceController
    {
        /// <summary>
        /// Обновление объекта HostServiceModel
        /// </summary>
        public Func<HostServiceModel, IResult> update = (data) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host-service"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostServiceModel>(e.Data);

                    if (((HostServiceModel?)outputData)?.Id == null)
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
        /// Создание объекта HostServiceModel
        /// </summary>
        public Func<HostServiceModel, IResult> create = (data) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host-service"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostServiceModel>(e.Data);

                    if (((HostServiceModel?)outputData)?.Id == null)
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
        /// Получение всех объектов HostServiceModel
        /// </summary>
        public Func<IResult> getAll = () =>
        {
            var flag = false;
            HostServiceModel[]? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host-service"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostServiceModel[]>(e.Data);
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
        /// Получение конкретного объекта HostServiceModel
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host-service"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostServiceModel>(e.Data);

                    if (((HostServiceModel?)outputData)?.Id == null)
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
        /// Удаление объекта HostServiceModel
        /// </summary>
        public Func<string, IResult> delete = (id) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/host-service"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<HostServiceModel>(e.Data);

                    if (((HostServiceModel?)outputData)?.Id == null)
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
