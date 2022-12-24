using Newtonsoft.Json;
using oodb_project.models;
using WebSocketSharp;

namespace oodb_project.controllers.perst
{
    public class DataSourceController
    {
        /// <summary>
        /// Обновление объекта AdminModel
        /// </summary>
        public Func<AdminModel, IResult> update = (newData) =>
        {
            return Results.Json("");
        };

        /// <summary>
        /// Создание объекта AdminModel
        /// </summary>
        public Func<AdminModel, IResult> create = (data) =>
        {
            return Results.Json(data);
        };

        /// <summary>
        /// Получение всех объектов DataSource
        /// </summary>
        public Func<IResult> getAll = () =>
        {
            var flag = false;
            DataSourceModel[]? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/data-source"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<DataSourceModel[]>(e.Data);
                    flag = true;
                };

                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(new HttpModel("/get/all", null)));

                while (!flag)
                {
                    Console.WriteLine(flag);
                }

            }

            return Results.Json(outputData);
        };

        /// <summary>
        /// Получение конкретного объекта AdminModel
        /// </summary>
        public Func<string, IResult> get = (id) =>
        {
            return Results.Json("");
        };

        /// <summary>
        /// Удаление объекта AdminModel
        /// </summary>
        public Func<string, IResult> delete = (id) =>
        {
            return Results.Json("");
        };
    }
}
