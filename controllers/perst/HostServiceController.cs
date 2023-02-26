using Newtonsoft.Json;
using oodb_project.models;
using WebSocketSharp;

namespace oodb_project.controllers.perst
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов HostService
    /// </summary>
    public class HostServiceController : BaseController<HostServiceModel>
    {
        public HostServiceController() : base("ws://127.0.0.1/host-service") { }

        /// <summary>
        /// Обновление объекта в коллекции
        /// </summary>
        /// <param name="data">Новые данные объекта в коллекции</param>
        /// <returns>Обновлённый объект</returns>
        public IResult Update(HostServiceModel data)
        {
            return TemplateRequest("/update", JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// Создание нового объекта в коллекции
        /// </summary>
        /// <param name="data">Данные объекта</param>
        /// <returns>Созданный объект</returns>
        public IResult Create(HostServiceModel data)
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
    }
}
