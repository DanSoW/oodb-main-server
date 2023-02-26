using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using oodb_project.models;

namespace oodb_project.controllers.db4o
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов HostService
    /// </summary>
    public class HostServiceController : BaseController<HostServiceModel>
    {
        public HostServiceController(IObjectContainer db) : base(db) { }

        /// <summary>
        /// Обновление объекта в коллекции
        /// </summary>
        /// <param name="data">Новые данные объекта</param>
        /// <returns>Обновлённый объект</returns>
        public IResult Update(HostServiceModel data)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                IList<HostServiceModel> list1 = _db.Query<HostServiceModel>(value => value.Id == data.Id);
                if (list1.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostServiceModel с id = {data.Id} не найдено!"));
                }

                HostServiceModel hostService = list1[0];

                IList<HostModel> list2 = _db.Query<HostModel>(value => value.Id == hostService.HostId);
                if (list2.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostModel с id = {hostService.HostId} не найдено!"));
                }

                IList<ServiceModel> list3 = _db.Query<ServiceModel>(value => value.Id == hostService.ServiceId);
                if (list3.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostModel с id = {hostService.ServiceId} не найдено!"));
                }

                hostService.HostId = data.HostId;
                hostService.ServiceId = data.ServiceId;

                _db.Store(hostService);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }

            return Results.Json(data);
        }

        /// <summary>
        /// Создание нового объекта в коллекции
        /// </summary>
        /// <param name="data">Данные объекта</param>
        /// <returns>Созданный объект</returns>
        public new IResult Create(HostServiceModel data)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Автоматическая генерация UUID
                data.Id = Guid.NewGuid().ToString();

                IList<HostModel> list2 = _db.Query<HostModel>(value => value.Id == data.HostId);
                if (list2.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostModel с id = {data.HostId} не найдено!"));
                }

                IList<ServiceModel> list3 = _db.Query<ServiceModel>(value => value.Id == data.ServiceId);
                if (list3.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostModel с id = {data.ServiceId} не найдено!"));
                }

                // Сохранение модели в ООДБ
                _db.Store(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }

            return Results.Json(data);
        }



        /// <summary>
        /// Получение всех объектов из коллекции с помощью SODA-запроса
        /// </summary>
        /// <returns>Список объектов из коллекции</returns>
        public new IResult GetAll()
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                IQuery query = _db.Query();
                query.Constrain(typeof(HostServiceModel));

                IObjectSet result = query.Execute();

                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        }
    }
}
