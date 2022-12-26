using Newtonsoft.Json;
using oodb_project.constants;
using oodb_project.models;
using WebSocketSharp;

namespace oodb_project.controllers.perst
{
    public class ServiceController
    {
        /// <summary>
        /// Обновление объекта ServiceModel
        /// </summary>
        public Func<ServiceModel, IResult> update = (data) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/service"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<ServiceModel>(e.Data);

                    if (((ServiceModel?)outputData)?.Id == null)
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
        /// Создание объекта ServiceModel
        /// </summary>
        public Func<ServiceModel, IResult> create = (data) =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/service"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<ServiceModel>(e.Data);

                    if (((ServiceModel?)outputData)?.Id == null)
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
        /// Получение всех объектов ServiceModel
        /// </summary>
        public Func<IResult> getAll = () =>
        {
            var flag = false;
            byte tick = 0;

            void TimerCallback(object? o)
            {
                if(tick == 0)
                {
                    tick++;
                    return;
                }

                flag = true;
            }

            ServiceModel[]? outputData = null;
            Timer? timer = null;

            using (var ws = new WebSocket("ws://127.0.0.1/service"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<ServiceModel[]>(e.Data);
                    flag = true;
                };

                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(new HttpModel("/get/all", null)));
                timer = new Timer(TimerCallback, null, 0, HttpConfig.TIME_AWAIT);

                while (!flag)
                {
                    Console.WriteLine(flag);
                }

                timer.Dispose();
            }

            return Results.Json(outputData);
        };

        /// <summary>
        /// Получение конкретного объекта ServiceModel
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            var flag = false;
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/service"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<ServiceModel>(e.Data);

                    if (((ServiceModel?)outputData)?.Id == null)
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
        /// Удаление объекта ServiceModel
        /// </summary>
        public Func<string, IResult> delete = (id) =>
        {
            var flag = false;
            object? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/service"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<ServiceModel>(e.Data);

                    if (((ServiceModel?)outputData)?.Id == null)
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

        /// <summary>
        /// Получение всех объектов ServiceModel по определённому порту
        /// </summary>
        public Func<string, IResult> getByPort = (string port) =>
        {
            var flag = false;
            byte tick = 0;

            void TimerCallback(object? o)
            {
                if (tick == 0)
                {
                    tick++;
                    return;
                }

                flag = true;
            }

            ServiceModel[]? outputData = null;
            Timer? timer = null;

            using (var ws = new WebSocket("ws://127.0.0.1/service"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<ServiceModel[]>(e.Data);
                    flag = true;
                };

                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(new HttpModel("/get/by/port", port)));
                timer = new Timer(TimerCallback, null, 0, HttpConfig.TIME_AWAIT);

                while (!flag)
                {
                    Console.WriteLine(flag);
                }

                timer.Dispose();
            }

            return Results.Json(outputData);
        };
    }
}
