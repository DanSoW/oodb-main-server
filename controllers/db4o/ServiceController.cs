using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Microsoft.AspNetCore.Mvc;
using oodb_project.models;
using oodb_project.models.Service;
using Db4objects.Db4o.Linq;
using oodb_project.controllers.predicates.Service;

namespace oodb_project.controllers.db4o
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов Service
    /// </summary>
    public class ServiceController : BaseController<ServiceModel>
    {
        public ServiceController(IObjectContainer db) : base(db) { }


        /// <summary>
        /// Получение списка объектов коллекции, с помощью комплексного запроса
        /// </summary>
        /// <param name="values">Значения фильтра для поиска</param>
        /// <returns>Список объектов</returns>
        public IResult GetAllComplex([FromBody] ServiceQuery values)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                IObjectSet result = _db.Query(
                    new ServiceComplexQuery
                    {
                        port = values.port
                    }
                );

                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        }

        /// <summary>
        /// Получение списка объектов с помощью LINQ
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public IResult GetAllLinq([FromBody] ServiceQuery values)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                IEnumerable<ServiceModel> result = from ServiceModel model in _db
                                                   where model.Port == values.port
                                                   select model;

                if (result.Count() == 0)
                {
                    return Results.Json(new MessageModel($"Объектов не найдено!"));
                }

                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        }

        /// <summary>
        /// Обновление объекта ServiceModel
        /// </summary>
        public IResult Update(ServiceModel newData)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                IList<ServiceModel> list1 = _db.Query<ServiceModel>(value => value.Id == newData.Id);
                if (list1.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа ServiceModel с id = {newData.Id} не найдено!"));
                }

                ServiceModel data = list1[0];

                IList<DataSourceModel> list2 = _db.Query<DataSourceModel>(value => value.Id == newData.DataSourceId);
                if (list2.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа DataSourceModel с id = {newData.DataSourceId} не найдено!"));
                }

                data.TimeUpdate = newData.TimeUpdate;
                data.DataSourceId = newData.DataSourceId;
                data.Port = newData.Port;
                data.Name = newData.Name;

                _db.Store(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }

            return Results.Json(newData);
        }

        /// <summary>
        /// Создание нового объекта в коллекции
        /// </summary>
        /// <param name="data">Данные об объекте</param>
        /// <returns>Созданный объект</returns>
        public new IResult Create(ServiceModel data)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Автоматическая генерация UUID
                data.Id = Guid.NewGuid().ToString();

                IList<DataSourceModel> list2 = _db.Query<DataSourceModel>(value => value.Id == data.DataSourceId);
                if (list2.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа DataSourceModel с id = {data.DataSourceId} не найдено!"));
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
    }
}
