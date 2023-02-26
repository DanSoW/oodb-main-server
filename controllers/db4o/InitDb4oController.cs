﻿using Db4objects.Db4o;
using oodb_project.constants;

namespace oodb_project.controllers.db4o
{
    /// <summary>
    /// Класс, содержащий методы для инициализации маршрутов в рамках работы с базой данных db4o
    /// </summary>
    public class InitDb4oController
    {
        private static WebApplication? _app;
        private static IObjectContainer? _db;

        public InitDb4oController(WebApplication app, IObjectContainer db)
        {
            _app = app;
            _db = db;
        }

        public void InitRoutes()
        {
            if((_db == null) || (_app == null)) 
            {
                return;
            }

            /* ----------- */
            /* CRUD операции для HostModel */
            /* ----------- */
            var hostController = new HostController(_db);

            _app.MapPost(ApiDb4oUrl.API_SAVE_HOST, hostController.Create);
            _app.MapPost(ApiDb4oUrl.API_UPDATE_HOST, hostController.Update);
            _app.MapPost(ApiDb4oUrl.API_DELETE_HOST, hostController.Delete);
            _app.MapGet(ApiDb4oUrl.API_GET_HOST, hostController.Get);
            _app.MapGet(ApiDb4oUrl.API_GET_ALL_HOST, hostController.GetAll);

            _app.MapGet(ApiDb4oUrl.API_COMPLEX_HOST, hostController.ComplexQuery);
            _app.MapGet(ApiDb4oUrl.API_COMPLEX_LINQ_HOST, hostController.ComplexQueryLinq);

            /* ----------- */
            /* CRUD операции для Admin */
            /* ----------- */
            var adminController = new AdminController(_db);

            _app.MapPost(ApiDb4oUrl.API_SAVE_ADMIN, adminController.Create);
            _app.MapPost(ApiDb4oUrl.API_UPDATE_ADMIN, adminController.Update);
            _app.MapPost(ApiDb4oUrl.API_DELETE_ADMIN, adminController.Delete);
            _app.MapGet(ApiDb4oUrl.API_GET_ADMIN, adminController.Get);
            _app.MapGet(ApiDb4oUrl.API_GET_ALL_ADMIN, adminController.GetAll);

            /* ----------- */
            /* CRUD операции для DataSource */
            /* ----------- */
            var dataSourceController = new DataSourceController(_db);

            _app.MapPost(ApiDb4oUrl.API_SAVE_DATA_SOURCE, dataSourceController.Create);
            _app.MapPost(ApiDb4oUrl.API_UPDATE_DATA_SOURCE, dataSourceController.Update);
            _app.MapPost(ApiDb4oUrl.API_DELETE_DATA_SOURCE, dataSourceController.Delete);
            _app.MapGet(ApiDb4oUrl.API_GET_DATA_SOURCE, dataSourceController.Get);
            _app.MapGet(ApiDb4oUrl.API_GET_ALL_DATA_SOURCE, dataSourceController.GetAll);

            /* ----------- */
            /* CRUD операции для Service */
            /* ----------- */
            var serviceController = new ServiceController(_db);

            _app.MapPost(ApiDb4oUrl.API_SAVE_SERVICE, serviceController.Create);
            _app.MapPost(ApiDb4oUrl.API_UPDATE_SERVICE, serviceController.Update);
            _app.MapPost(ApiDb4oUrl.API_DELETE_SERVICE, serviceController.Delete);
            _app.MapGet(ApiDb4oUrl.API_GET_SERVICE, serviceController.Get);
            _app.MapGet(ApiDb4oUrl.API_GET_ALL_SERVICE, serviceController.GetAll);

            _app.MapGet(ApiDb4oUrl.API_COMPLEX_SERVICE, serviceController.GetAllComplex);
            _app.MapGet(ApiDb4oUrl.API_COMPLEX_LINQ_SERVICE, serviceController.GetAllLinq);

            /* ----------- */
            /* CRUD операции для HostService */
            /* ----------- */
            var hostServiceController = new HostServiceController(_db);

            _app.MapPost(ApiDb4oUrl.API_SAVE_HOST_SERVICE, hostServiceController.Create);
            _app.MapPost(ApiDb4oUrl.API_UPDATE_HOST_SERVICE, hostServiceController.Update);
            _app.MapPost(ApiDb4oUrl.API_DELETE_HOST_SERVICE, hostServiceController.Delete);
            _app.MapGet(ApiDb4oUrl.API_GET_HOST_SERVICE, hostServiceController.Get);
            _app.MapGet(ApiDb4oUrl.API_GET_ALL_HOST_SERVICE, hostServiceController.GetAll);

            /* ----------- */
            /* CRUD операции для MonitorApp */
            /* ----------- */
            var monitorAppController = new MonitorAppController(_db);

            _app.MapPost(ApiDb4oUrl.API_SAVE_MONITOR_APP, monitorAppController.Create);
            _app.MapPost(ApiDb4oUrl.API_UPDATE_MONITOR_APP, monitorAppController.Update);
            _app.MapPost(ApiDb4oUrl.API_DELETE_MONITOR_APP, monitorAppController.Delete);
            _app.MapGet(ApiDb4oUrl.API_GET_MONITOR_APP, monitorAppController.Get);
            _app.MapGet(ApiDb4oUrl.API_GET_ALL_MONITOR_APP, monitorAppController.GetAll);

            _app.MapGet(ApiDb4oUrl.API_GET_SODA_MONITOR_APP, monitorAppController.GetSoda);
        }
    }
}
