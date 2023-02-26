using Db4objects.Db4o;
using oodb_project.models;

namespace oodb_project.controllers.db4o
{
    /// <summary>
    /// Абстрактный класс, реализующий обобщённые методы CRUD-операций для коллекций объектов
    /// </summary>
    /// <typeparam name="T">Тип данных моделей, используемых в рамках CRUD-операций</typeparam>
    public abstract class BaseController<T>
        where T : IdModel
    {
        // Коллекция входных параметров
        protected IObjectContainer? _db;

        /// <summary>
        /// Конструктор абстрактного класса
        /// </summary>
        /// <param name="collection">Ссылка на коллекцию</param>
        public BaseController(IObjectContainer? db)
        {
            _db = db;
        }

        /// <summary>
        /// Метод для создания нового объекта коллекции
        /// </summary>
        /// <param name="data">Данные объекта коллекции</param>
        /// <returns>Созданный объект коллекции</returns>
        protected IResult Create(T data)
        {
            // Проверка подключения к базе данных
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
        }

        /// <summary>
        /// Метод для получения всех объектов определённого типа
        /// </summary>
        /// <returns>Результат работы функции (массив документов)</returns>
        public IResult GetAll()
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Поиск всех данных по текущей модели
                IObjectSet result = _db.QueryByExample(typeof(T));

                // Возвращение списка моделей
                return Results.Json(result);
            }
            catch (Exception e)
            {
                return Results.Json(new MessageModel(e.Message));
            }
        }

        /// <summary>
        /// Метод для получения конкретного объекта из коллекции
        /// </summary>
        /// <param name="id">Идентификатор искомого объекта</param>
        /// <returns>Результат работы метода (конкретный объект)</returns>
        public IResult Get(string id)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Получение конкретной модели
                T data = _db.Query<T>(value => value.Id == id)[0];

                return Results.Json(data);
            }
            catch (Exception)
            {
                return Results.Json(new MessageModel($"Модели с Id = {id} нет в ООБД"));
            }
        }

        /// <summary>
        /// Метод для удаления объекта из коллекции
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Удалённый объект коллекции</returns>
        public IResult Delete(string id)
        {
            if (_db == null)
            {
                return Results.Json(new MessageModel("Подключение к ООБД отсутствует"));
            }

            try
            {
                // Получение конкретного объекта
                var data = _db.Query<T>(value => value.Id == id);
                if(data.Count <= 0)
                {
                    return Results.Json(new MessageModel($"Модели с Id = {id} нет в ООБД"));
                }

                var cloneData = data.First();

                // Удаление объекта
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
