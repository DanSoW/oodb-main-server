using Db4objects.Db4o;
using oodb_project.models;

namespace oodb_project.controllers.db4o
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов Admin
    /// </summary>
    public class AdminController : BaseController<AdminModel>
    {
        public AdminController(IObjectContainer db) : base(db) { }

        /// <summary>
        /// Обновление объекта в коллекции
        /// </summary>
        /// <param name="data">Данные об объекте в коллекции</param>
        /// <returns>Обновлённый объект</returns>
        public IResult Update(AdminModel data)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                AdminModel findObj = _db.Query<AdminModel>(value => value.Id == data.Id)[0];
                findObj.Email = data.Email;

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
        public new IResult Create(AdminModel data)
        {
            return base.Create(data);
        }

        /// <summary>
        /// Удаление объекта из коллекции
        /// </summary>
        /// <param name="id">Идентификатор объекта в коллекции</param>
        /// <returns>Удаленённый объект коллекции</returns>
        public new IResult Delete(string id)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                var data = _db.Query<AdminModel>(value => value.Id == id);
                if (data.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Модели с Id = {id} нет в ООБД"));
                }

                // Удаление связанных данных
                var monitorApps = _db.Query<MonitorAppModel>(value => value.AdminId == id);
                foreach (var item in monitorApps)
                {
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
