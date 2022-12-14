using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Microsoft.AspNetCore.Mvc;
using oodb_project.models;
using oodb_project.models.Service;
using Db4objects.Db4o.Linq;
using oodb_project.controllers.predicates.Service;

namespace oodb_project.controllers.db4o
{
    public class ServiceController
    {
        private static IObjectContainer? _db;

        public ServiceController(IObjectContainer db)
        {
            _db = db;
        }


        /// <summary>
        /// Получение всех объектов ServiceModel
        /// </summary>
        public Func<ServiceQuery, IResult> getAllComplex = ([FromBody] values) =>
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
        };

        /// <summary>
        /// Получение всех объектов ServiceModel
        /// </summary>
        public Func<ServiceQuery, IResult> getAllComplexLinq = ([FromBody] values) =>
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
        };

        /// <summary>
        /// Обновление объекта ServiceModel
        /// </summary>
        public Func<ServiceModel, IResult> update = (newData) =>
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
        };

        /// <summary>
        /// Создание объекта ServiceModel
        /// </summary>
        public Func<ServiceModel, IResult> create = (data) =>
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
        };

        /// <summary>
        /// Получение объекта ServiceModel
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                ServiceModel data = _db.Query<ServiceModel>(value => value.Id == id)[0];

                return Results.Json(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Получение всех объектов ServiceModel
        /// </summary>
        public Func<IResult> getAll = () =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Получение всех записей из DataSource с помощью SODA-запроса
                IQuery query = _db.Query();
                query.Constrain(typeof(ServiceModel));

                IObjectSet result = query.Execute();

                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Удаление объекта ServiceModel
        /// </summary>
        public Func<string, IResult> delete = (id) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Получение конкретной модели
                ServiceModel data = _db.Query<ServiceModel>(value => value.Id == id)[0];
                _db.Delete(data);

                return Results.Json(data);
            }
            catch (Exception)
            {
                return Results.Json(new MessageModel($"Модели с Id = {id} нет в ООБД"));
            }
        };
    }
}
