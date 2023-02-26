using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Microsoft.AspNetCore.Mvc;
using oodb_project.controllers.predicates.Host;
using oodb_project.models;
using oodb_project.models.Host;

namespace oodb_project.controllers.db4o
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов Host
    /// </summary>
    public class HostController : BaseController<HostModel>
    {
        public HostController(IObjectContainer db) : base(db) { }

        /// <summary>
        /// Выполнение комплексного запроса HostQuery
        /// </summary>
        public IResult ComplexQuery([FromBody]HostQuery values)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Выполнение комплексного запроса
                IObjectSet result = _db.Query(
                    new HostComplexQuery
                    {
                        IPv4 = values.IPv4,
                        System = values.System,
                    }
                );

                if (result.Count == 0)
                {
                    return Results.Json(new MessageModel($"Объекта не найдено!"));
                }

                // Получение конкретной модели
                HostModel? data = (HostModel?)result[0];

                return Results.Json(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        }

        /// <summary>
        /// Выполнение комплексного запроса HostQuery на базе LINQ
        /// </summary>
        public IResult ComplexQueryLinq([FromBody]HostQuery values)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Выполнение запроса
                IEnumerable<HostModel> result = from HostModel model in _db
                                                where model.IPv4 == values.IPv4 && model.System == values.System
                                                select model;

                if (result.Count() == 0)
                {
                    return Results.Json(new MessageModel($"Объекта не найдено!"));
                }

                // Возвращение первого совпадения
                HostModel? data = result.First();

                return Results.Json(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        }

        /// <summary>
        /// Обновление объекта в коллекции
        /// </summary>
        /// <param name="data">Данные об объекте в коллекции</param>
        /// <returns>Обновлённый объект</returns>
        public IResult Update(HostModel data)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                HostModel host = _db.Query<HostModel>(value => value.Id == data.Id)[0];
                host.Url = data.Url;
                host.IPv4 = data.IPv4;
                host.System = data.System;

                _db.Store(host);
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
        public new IResult Create(HostModel data)
        {
            return base.Create(data);
        }

        /// <summary>
        /// Каскадное удаление объекта Host
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
                var data = _db.Query<HostModel>(value => value.Id == id);
                if(data.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Модели с Id = {id} нет в ООБД"));
                }

                // Удаление связанных элементов с таблицей Host
                var hostServices = _db.Query<HostServiceModel>(value => value.HostId == id);
                foreach(var item in hostServices)
                {
                    _db.Delete(item);
                }

                var monitorApps = _db.Query<MonitorAppModel>(value => value.HostId == id);
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
