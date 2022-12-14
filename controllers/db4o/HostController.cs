using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Microsoft.AspNetCore.Mvc;
using oodb_project.controllers.predicates.Host;
using oodb_project.models;
using oodb_project.models.Host;

namespace oodb_project.controllers.db4o
{
    public class HostController
    {
        private static IObjectContainer? _db;

        public HostController(IObjectContainer db)
        {
            _db = db;
        }

        /// <summary>
        /// Выполнение комплексного запроса HostQuery
        /// </summary>
        public Func<HostQuery, IResult> complex = ([FromBody] values) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
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
        };

        /// <summary>
        /// Выполнение комплексного запроса HostQuery на базе LINQ
        /// </summary>
        public Func<HostQuery, IResult> complexLinq = ([FromBody] values) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                IEnumerable<HostModel> result = from HostModel model in _db
                                                where model.IPv4 == values.IPv4 && model.System == values.System
                                                select model;

                if (result.Count() == 0)
                {
                    return Results.Json(new MessageModel($"Объекта не найдено!"));
                }

                HostModel? data = result.Last();

                return Results.Json(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Обновление объекта Host
        /// </summary>
        public Func<HostModel, IResult> update = (newData) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                HostModel data = _db.Query<HostModel>(value => value.Id == newData.Id)[0];
                data.Url = newData.Url;
                data.IPv4 = newData.IPv4;
                data.System = newData.System;

                _db.Store(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }

            return Results.Json(newData);
        };

        /// <summary>
        /// Создание объекта Host
        /// </summary>
        public Func<HostModel, IResult> create = (data) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Автоматическая генерация UUID
                data.Id = Guid.NewGuid().ToString();

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
        /// Получение всех объектов Host
        /// </summary>
        public Func<IResult> getAll = () =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Поиск всех данных по текущей модели
                IObjectSet result = _db.QueryByExample(typeof(HostModel));

                // Возвращение списка моделей
                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Получение конкретного объекта Host
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Получение конкретной модели
                HostModel data = _db.Query<HostModel>(value => value.Id == id)[0];

                return Results.Json(data);
            }
            catch (Exception)
            {
                return Results.Json(new MessageModel($"Модели с Id = {id} нет в ООБД"));
            }
        };

        /// <summary>
        /// Удаление объекта Host
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
                HostModel data = _db.Query<HostModel>(value => value.Id == id)[0];
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
