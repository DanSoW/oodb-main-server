using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using oodb_project.models;

namespace oodb_project.controllers.db4o
{
    public class DataSourceController
    {
        private static IObjectContainer? _db;

        public DataSourceController(IObjectContainer db)
        {
            _db = db;
        }

        /// <summary>
        /// Обновление объекта DataSourceModel
        /// </summary>
        public Func<DataSourceModel, IResult> update = (newData) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                DataSourceModel data = _db.Query<DataSourceModel>(value => value.Id == newData.Id)[0];
                data.Url = newData.Url;
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
        /// Создание объекта DataSourceModel
        /// </summary>
        public Func<DataSourceModel, IResult> create = (data) =>
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
        /// Получение объекта DataSource
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                DataSourceModel data = _db.Query<DataSourceModel>(value => value.Id == id)[0];

                return Results.Json(data);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Получение всех объектов DataSource
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
                query.Constrain(typeof(DataSourceModel));

                IObjectSet result = query.Execute();

                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        };

        /// <summary>
        /// Удаление объекта DataSource
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
                DataSourceModel data = _db.Query<DataSourceModel>(value => value.Id == id)[0];
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
