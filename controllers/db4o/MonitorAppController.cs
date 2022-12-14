using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Microsoft.AspNetCore.Mvc;
using oodb_project.models;
using oodb_project.models.MonitorApp;

namespace oodb_project.controllers.db4o
{
    public class MonitorAppController
    {
        private static IObjectContainer? _db;

        public MonitorAppController(IObjectContainer db)
        {
            _db = db;
        }

        /// <summary>
        /// Получение объекта MonitorAppModel
        /// </summary>
        public Func<MonitorAppQuery, IResult> getSoda = ([FromBody] values) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                /*IQuery query = _db.Query();
                query.Constrain(typeof(MonitorAppModel));

                IConstraint constr = query.Descend("name")
                        .Constrain(values.Name);
                query.Descend("url")
                        .Constrain(values.Url).And(constr);
                IObjectSet result = query.Execute();*/

                IObjectSet result = _db.QueryByExample(
                    new MonitorAppModel
                    {
                        Name = values.Name,
                        Url = values.Url
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
        /// Обновление объекта MonitorAppModel
        /// </summary>
        public Func<MonitorAppModel, IResult> update = (newData) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                IList<MonitorAppModel> list1 = _db.Query<MonitorAppModel>(value => value.Id == newData.Id);
                if (list1.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа MonitorAppModel с id = {newData.Id} не найдено!"));
                }

                MonitorAppModel data = list1[0];

                IList<HostModel> list2 = _db.Query<HostModel>(value => value.Id == newData.HostId);
                if (list2.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostModel с id = {newData.HostId} не найдено!"));
                }

                IList<AdminModel> list3 = _db.Query<AdminModel>(value => value.Id == newData.AdminId);
                if (list3.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа AdminModel с id = {newData.AdminId} не найдено!"));
                }

                data.Name = newData.Name;
                data.Url = newData.Url;
                data.HostId = newData.HostId;
                data.AdminId = newData.AdminId;

                _db.Store(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }

            return Results.Json(newData);
        };

        /// <summary>
        /// Создание объекта MonitorAppModel
        /// </summary>
        public Func<MonitorAppModel, IResult> create = (data) =>
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

                IList<AdminModel> list3 = _db.Query<AdminModel>(value => value.Id == data.AdminId);
                if (list3.Count == 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа AdminModel с id = {data.AdminId} не найдено!"));
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
        /// Получение объекта MonitorAppModel
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                MonitorAppModel data = _db.Query<MonitorAppModel>(value => value.Id == id)[0];

                return Results.Json(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Получение всех объектов MonitorAppModel
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
                query.Constrain(typeof(MonitorAppModel));

                IObjectSet result = query.Execute();

                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Удаление объекта MonitorAppModel
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
                MonitorAppModel data = _db.Query<MonitorAppModel>(value => value.Id == id)[0];
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
