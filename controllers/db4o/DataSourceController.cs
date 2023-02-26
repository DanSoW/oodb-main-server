using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using oodb_project.models;

namespace oodb_project.controllers.db4o
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов DataSource
    /// </summary>
    public class DataSourceController : BaseController<DataSourceModel>
    {
        public DataSourceController(IObjectContainer db) : base(db) { }

        /// <summary>
        /// Обновление объекта в коллекции
        /// </summary>
        /// <param name="data">Данные об объекте в коллекции</param>
        /// <returns>Обновлённый объект</returns>
        public IResult Update(DataSourceModel data)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                DataSourceModel findObj = _db.Query<DataSourceModel>(value => value.Id == data.Id)[0];
                findObj.Url = data.Url;
                findObj.Name = data.Name;

                _db.Store(findObj);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }

            return Results.Json(data);
        }

        /// <summary>
        /// Создание нового объекта коллекции
        /// </summary>
        /// <param name="data">Данные об объекте</param>
        /// <returns>Созданный объект</returns>
        public new IResult Create(DataSourceModel data)
        {
            return base.Create(data);
        }

        /// <summary>
        /// Получение всех объектов коллекции с помощью SODA-запроса
        /// </summary>
        /// <returns>Список всех объектов коллекции</returns>
        public new IResult GetAll()
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Получение всех записей из DataSource с помощью SODA-запроса
                IQuery query = _db.Query();

                // Установка ограничений для поиска
                query.Constrain(typeof(DataSourceModel));

                // Получение результата поиска
                IObjectSet result = query.Execute();

                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        }

        /// <summary>
        /// Каскадное удаление объекта DataSource
        /// </summary>
        /// <param name="id">Идентификатор объекта в коллекции</param>
        /// <returns>Удалённый объект</returns>
        public new IResult Delete(string id)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                var data = _db.Query<DataSourceModel>(value => value.Id == id);
                if (data.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Модели с Id = {id} нет в ООБД"));
                }

                var services = _db.Query<ServiceModel>(value => value.DataSourceId == id);
                foreach (var item in services)
                {
                    var hostServices = _db.Query<HostServiceModel>(value => value.ServiceId == item.Id);
                    foreach(var hostService in hostServices)
                    {
                        _db.Delete(hostService);
                    }

                    _db.Delete(item);
                }

                var cloneData = data.First();

                // Удаление модели
                _db.Delete(data.First());

                return Results.Json(cloneData);
            }
            catch (Exception)
            {
                return Results.Json(new MessageModel($"Модели с Id = {id} нет в ООБД"));
            }
        }
    }
}
