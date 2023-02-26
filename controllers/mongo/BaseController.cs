using Newtonsoft.Json;
using oodb_project.models;
using System.Net;

namespace oodb_project.controllers.mongo
{
    /// <summary>
    /// Базовый контроллер для обращения к сервису oodb-mongo-server
    /// </summary>
    /// <typeparam name="T">Тип данных обобщённых моделей</typeparam>
    public abstract class BaseController<T> where T : IdModel
    {
        /// <summary>
        /// Базовый URL-адрес, к которому отправляются все запросы
        /// </summary>
        public static string BASE_URL = "http://localhost:5246/api";

        /// <summary>
        /// Получение экземпляра объекта
        /// </summary>
        /// <param name="url">Путь, по которому отправляется запрос на получение экземпляра</param>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Экземпляр объекта коллекции</returns>
        public IResult Get(string url, string id)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(BASE_URL + url + $"/{id}");
            httpRequest.Method = "GET";
            httpRequest.ContentType = "application/json";

            string result = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return Results.Json(JsonConvert.DeserializeObject<T>(result));
        }

        /// <summary>
        /// Получение списка объектов в коллекции
        /// </summary>
        /// <param name="url">Путь, по которому отправляется запрос на получение множества объектов коллекции</param>
        /// <returns>Множество объектов коллекции</returns>
        public IResult GetAll(string url)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(BASE_URL + url);
            httpRequest.Method = "GET";
            httpRequest.ContentType = "application/json";

            string result = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return Results.Json(JsonConvert.DeserializeObject<T[]>(result));
        }

        /// <summary>
        /// Удаление объекта из коллекции
        /// </summary>
        /// <param name="url">Путь</param>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Удалённый объект</returns>
        public IResult Delete(string url, string id)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(BASE_URL + url + $"/{id}");
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";

            string result = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return Results.Json(JsonConvert.DeserializeObject<T>(result));
        }

        /// <summary>
        /// Создание объекта в коллекции
        /// </summary>
        /// <param name="url">Путь</param>
        /// <param name="model">Данные объекта</param>
        /// <returns>Созданный объект в коллекции</returns>
        public IResult Create(string url, T model)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(BASE_URL + url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";

            string input = JsonConvert.SerializeObject(model);

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(input);
            }

            string result = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return Results.Json(JsonConvert.DeserializeObject<T>(result));
        }

        /// <summary>
        /// Обновление объекта в коллекции
        /// </summary>
        /// <param name="url">Путь</param>
        /// <param name="model">Новые данные объекта в коллекции</param>
        /// <returns>Обновленный объект</returns>
        public IResult Update(string url, T model)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(BASE_URL + url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";

            string input = JsonConvert.SerializeObject(model);

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(input);
            }

            string result = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return Results.Json(JsonConvert.DeserializeObject<T>(result));
        }
    }
}
