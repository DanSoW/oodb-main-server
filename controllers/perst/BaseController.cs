using Newtonsoft.Json;
using oodb_project.constants;
using oodb_project.models;
using WebSocketSharp;

namespace oodb_project.controllers.perst
{
    /// <summary>
    /// Базовый контроллер для обращения к сервису oodb-mongo-server
    /// </summary>
    /// <typeparam name="T">Тип данных обобщённых моделей</typeparam>
    public abstract class BaseController<T> where T : IdModel
    {
        /// <summary>
        /// Базовый URL-адрес, к которому отправляются все запросы
        /// </summary>
        protected string _baseUrl;

        public BaseController(string baseURL)
        {
            _baseUrl = baseURL;
        }

        /// <summary>
        /// Шаблонный запрос
        /// </summary>
        /// <param name="url">Адрес</param>
        /// <returns>Результат выполнения запроса</returns>
        public IResult TemplateRequest(string url)
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

            T[]? outputData = null;
            Timer? timer = null;

            using (var ws = new WebSocket(_baseUrl))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<T[]>(e.Data);
                    flag = true;
                };

                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(new HttpModel(url, null)));
                timer = new Timer(TimerCallback, null, 0, HttpConfig.TIME_AWAIT);

                while (!flag)
                {
                    Console.WriteLine(flag);
                }

                timer.Dispose();
            }

            return Results.Json(outputData);
        }

        /// <summary>
        /// Шаблонный запрос
        /// </summary>
        /// <param name="url">Адрес</param>
        /// <param name="data">Данные</param>
        /// <returns>Результат выполнения запроса</returns>
        public IResult TemplateRequest(string url, string data)
        {
            var flag = false;
            object? outputData = null;
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
            Timer? timer = null;

            using (var ws = new WebSocket(_baseUrl))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<T>(e.Data);

                    if (((T?)outputData)?.Id == null)
                    {
                        outputData = JsonConvert.DeserializeObject<MessageModel>(e.Data);
                    }

                    flag = true;
                };

                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(
                    new HttpModel(
                        url,
                        data
                    )
                ));

                timer = new Timer(TimerCallback, null, 0, HttpConfig.TIME_AWAIT);
                while (!flag)
                {
                    Console.WriteLine(flag);
                }

                timer.Dispose();
            }

            return Results.Json(outputData);
        }
    }
}
