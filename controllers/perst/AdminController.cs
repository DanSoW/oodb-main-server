﻿using Newtonsoft.Json;
using oodb_project.models;
using WebSocketSharp;

namespace oodb_project.controllers.perst
{
    public class AdminController
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
            // Флаг задержки
            var flag = false;

            // Выходные данные
            AdminModel? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/admin"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<AdminModel>(e.Data);
                    flag = true;
                };

                // Подключение по WebSocket-соединению к приложению
                ws.Connect();

                ws.Send(JsonConvert.SerializeObject(
                    new HttpModel(
                        "/save",
                        JsonConvert.SerializeObject(data)
                    )
                ));

                // Бесконечный цикл для создания задержки обработки сообщения
                while (!flag)
                {
                    // bug(): если убрать Console.WriteLine бесконечный цикл будет длится вечно
                    Console.WriteLine(flag);
                }

            }

            return Results.Json(outputData);
        };

        /// <summary>
        /// Получение всех объектов AdminModel
        /// </summary>
        public Func<IResult> getAll = () =>
        {
            // Флаг задержки
            var flag = false;

            // Выходные данные
            AdminModel[]? outputData = null;

            using (var ws = new WebSocket("ws://127.0.0.1/admin"))
            {
                // Обработка получения сообщения с стороннего сервиса
                ws.OnMessage += (sender, e) =>
                {
                    outputData = JsonConvert.DeserializeObject<AdminModel[]>(e.Data);
                    flag = true;
                };

                // Подключение по WebSocket-соединению к приложению
                ws.Connect();

                // Отправка уточняющих данных
                ws.Send(JsonConvert.SerializeObject(new HttpModel("/get/all", null)));

                // Бесконечный цикл для создания задержки обработки сообщения
                while (!flag) {
                    // bug(): если убрать Console.WriteLine бесконечный цикл будет длится вечно
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
