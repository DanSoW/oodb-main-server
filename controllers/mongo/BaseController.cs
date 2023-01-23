using Newtonsoft.Json;
using oodb_project.models;
using System.Net;

namespace oodb_project.controllers.mongo
{
    public abstract class BaseController<T> where T : IdModel
    {
        public static string BASE_URL = "http://localhost:5246/api";

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
