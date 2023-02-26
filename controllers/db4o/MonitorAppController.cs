using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Microsoft.AspNetCore.Mvc;
using oodb_project.models;
using oodb_project.models.MonitorApp;

namespace oodb_project.controllers.db4o
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов MonitorApp
    /// </summary>
    public class MonitorAppController : BaseController<MonitorAppModel>
    {

        public MonitorAppController(IObjectContainer db) : base(db) { }

        /// <summary>
        /// Получение объекта MonitorAppModel
        /// </summary>
        public IResult GetSoda([FromBody] MonitorAppQuery values)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
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
        }

        /// <summary>
        /// Обновление объекта в коллекции
        /// </summary>
        /// <param name="data">Новые данные об объекте в коллекции</param>
        /// <returns>Обновлённые данные объекта</returns>
        public IResult Update(MonitorAppModel data)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                IList<MonitorAppModel> list1 = _db.Query<MonitorAppModel>(value => value.Id == data.Id);
                if (list1.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа MonitorAppModel с id = {data.Id} не найдено!"));
                }

                MonitorAppModel monitorApp = list1[0];

                IList<HostModel> list2 = _db.Query<HostModel>(value => value.Id == monitorApp.HostId);
                if (list2.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа HostModel с id = {monitorApp.HostId} не найдено!"));
                }

                IList<AdminModel> list3 = _db.Query<AdminModel>(value => value.Id == monitorApp.AdminId);
                if (list3.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Ошибка: объекта типа AdminModel с id = {monitorApp.AdminId} не найдено!"));
                }

                monitorApp.Name = data.Name;
                monitorApp.Url = data.Url;
                monitorApp.HostId = data.HostId;
                monitorApp.AdminId = data.AdminId;

                _db.Store(monitorApp);
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
        /// <param name="data">Данные об объекте</param>
        /// <returns>Созданный объект</returns>
        public new IResult Create(MonitorAppModel data)
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

                IList<AdminModel> list3 = _db.Query<AdminModel>(value => value.Id == data.AdminId);
                if (list3.Count <= 0)
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
        }
    }
}
