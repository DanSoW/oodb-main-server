using Newtonsoft.Json;
using oodb_project.constants;
using oodb_project.models;
using WebSocketSharp;

namespace oodb_project.controllers.perst
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов Service
    /// </summary>
    public class ServiceController : BaseController<ServiceModel>
    {
        public ServiceController() : base("ws://127.0.0.1/service") { }

        /// <summary>
        /// Обновление объекта в коллекции
        /// </summary>
        /// <param name="data">Новые данные объекта в коллекции</param>
        /// <returns>Обновлённый объект</returns>
        public IResult Update(ServiceModel data)
        {
            return TemplateRequest("/update", JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// Создание нового объекта в коллекции
        /// </summary>
        /// <param name="data">Данные объекта</param>
        /// <returns>Созданный объект</returns>
        public IResult Create(ServiceModel data)
        {
            return TemplateRequest("/save", JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// Получение множества объектов в коллекции
        /// </summary>
        /// <returns>Объекты в коллекции</returns>
        public IResult GetAll()
        {
            return TemplateRequest("/get/all");
        }

        /// <summary>
        /// Получение объекта из коллекции
        /// </summary>
        /// <param name="id">Идентификатор объекта в коллекции</param>
        /// <returns>Найденный объект по идентификатору</returns>
        public IResult Get(string id)
        {
            return TemplateRequest("/get", id);
        }

        /// <summary>
        /// Удаление объекта из коллекции
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Удалённый объект</returns>
        public IResult Delete(string id)
        {
            return TemplateRequest("/delete", id);
        }

        /// <summary>
        /// Полечение объектов с атрибутом, равным определённому значению
        /// </summary>
        /// <param name="port">Значение порта</param>
        /// <returns>Множество объектов</returns>
        public IResult GetByPort(string port)
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
        }
    }
}
