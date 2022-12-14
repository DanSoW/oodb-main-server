using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using oodb_project.models;

namespace oodb_project.controllers.db4o
{
    public class HostServiceController
    {
        private static IObjectContainer? _db;

        public HostServiceController(IObjectContainer db)
        {
            _db = db;
        }

        /// <summary>
        /// Обновление объекта HostServiceModel
        /// </summary>
        public Func<HostServiceModel, IResult> update = (newData) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                IList<HostServiceModel> list1 = _db.Query<HostServiceModel>(value => value.Id == newData.Id);
                if (list1.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostServiceModel с id = {newData.Id} не найдено!"));
                }

                HostServiceModel data = list1[0];

                IList<HostModel> list2 = _db.Query<HostModel>(value => value.Id == newData.HostId);
                if (list2.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostModel с id = {newData.HostId} не найдено!"));
                }

                IList<ServiceModel> list3 = _db.Query<ServiceModel>(value => value.Id == newData.ServiceId);
                if (list3.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostModel с id = {newData.ServiceId} не найдено!"));
                }

                data.HostId = newData.HostId;
                data.ServiceId = newData.ServiceId;

                _db.Store(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }

            return Results.Json(newData);
        };

        /// <summary>
        /// Создание объекта HostServiceModel
        /// </summary>
        public Func<HostServiceModel, IResult> create = (data) =>
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
                if (list2.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostModel с id = {data.HostId} не найдено!"));
                }

                IList<ServiceModel> list3 = _db.Query<ServiceModel>(value => value.Id == data.ServiceId);
                if (list3.Count == 0)
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
        };

        /// <summary>
        /// Получение объекта HostServiceModel
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                HostServiceModel data = _db.Query<HostServiceModel>(value => value.Id == id)[0];

                return Results.Json(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Получение всех объектов HostServiceModel
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
                query.Constrain(typeof(HostServiceModel));

                IObjectSet result = query.Execute();

                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Удаление объекта HostServiceModel
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
                HostServiceModel data = _db.Query<HostServiceModel>(value => value.Id == id)[0];
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
