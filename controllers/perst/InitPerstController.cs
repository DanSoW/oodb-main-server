using oodb_project.constants;

namespace oodb_project.controllers.perst
{
    /// <summary>
    /// Класс, содержащий методы для инициализации маршрутов в рамках работы с базой данных Perst
    /// </summary>
    public class InitPerstController
    {
        private static WebApplication? _app;

        public InitPerstController(WebApplication app)
        {
            _app = app;
        }

        public void InitRoutes()
        {
            if (_app == null)
            {
                return;
            }

            /* ----------- */
            /* CRUD операции для Admin */
            /* ----------- */
            var adminController = new AdminController();
            _app.MapPost(ApiPerstUrl.API_SAVE_ADMIN, adminController.Create);
            _app.MapPost(ApiPerstUrl.API_UPDATE_ADMIN, adminController.Update);
            _app.MapPost(ApiPerstUrl.API_DELETE_ADMIN, adminController.Delete);
            _app.MapGet(ApiPerstUrl.API_GET_ADMIN, adminController.Get);
            _app.MapGet(ApiPerstUrl.API_GET_ALL_ADMIN, adminController.GetAll);

            /* ----------- */
            /* CRUD операции для HostModel */
            /* ----------- */
            var hostController = new HostController();
            _app.MapPost(ApiPerstUrl.API_SAVE_HOST, hostController.Create);
            _app.MapPost(ApiPerstUrl.API_UPDATE_HOST, hostController.Update);
            _app.MapPost(ApiPerstUrl.API_DELETE_HOST, hostController.Delete);
            _app.MapGet(ApiPerstUrl.API_GET_HOST, hostController.Get);
            _app.MapGet(ApiPerstUrl.API_GET_ALL_HOST, hostController.GetAll);

            /* ----------- */
            /* CRUD операции для DataSource */
            /* ----------- */
            var dataSourceController = new DataSourceController();
            _app.MapPost(ApiPerstUrl.API_SAVE_DATA_SOURCE, dataSourceController.Create);
            _app.MapPost(ApiPerstUrl.API_UPDATE_DATA_SOURCE, dataSourceController.Update);
            _app.MapPost(ApiPerstUrl.API_DELETE_DATA_SOURCE, dataSourceController.Delete);
            _app.MapGet(ApiPerstUrl.API_GET_DATA_SOURCE, dataSourceController.Get);
            _app.MapGet(ApiPerstUrl.API_GET_ALL_DATA_SOURCE, dataSourceController.GetAll);

            /* ----------- */
            /* CRUD операции для Service */
            /* ----------- */
            var serviceController = new ServiceController();
            _app.MapPost(ApiPerstUrl.API_SAVE_SERVICE, serviceController.Create);
            _app.MapPost(ApiPerstUrl.API_UPDATE_SERVICE, serviceController.Update);
            _app.MapPost(ApiPerstUrl.API_DELETE_SERVICE, serviceController.Delete);
            _app.MapGet(ApiPerstUrl.API_GET_SERVICE, serviceController.Get);
            _app.MapGet(ApiPerstUrl.API_GET_ALL_SERVICE, serviceController.GetAll);
            _app.MapGet(ApiPerstUrl.API_GET_ALL_BY_PORT, serviceController.GetByPort);

            /* ----------- */
            /* CRUD операции для HostService */
            /* ----------- */
            var hostServiceController = new HostServiceController();
            _app.MapPost(ApiPerstUrl.API_SAVE_HOST_SERVICE, hostServiceController.Create);
            _app.MapPost(ApiPerstUrl.API_UPDATE_HOST_SERVICE, hostServiceController.Update);
            _app.MapPost(ApiPerstUrl.API_DELETE_HOST_SERVICE, hostServiceController.Delete);
            _app.MapGet(ApiPerstUrl.API_GET_HOST_SERVICE, hostServiceController.Get);
            _app.MapGet(ApiPerstUrl.API_GET_ALL_HOST_SERVICE, hostServiceController.GetAll);

            /* ----------- */
            /* CRUD операции для MonitorApp */
            /* ----------- */
            var monitorAppController = new MonitorAppController();
            _app.MapPost(ApiPerstUrl.API_SAVE_MONITOR_APP, monitorAppController.Create);
            _app.MapPost(ApiPerstUrl.API_UPDATE_MONITOR_APP, monitorAppController.Update);
            _app.MapPost(ApiPerstUrl.API_DELETE_MONITOR_APP, monitorAppController.Delete);
            _app.MapGet(ApiPerstUrl.API_GET_MONITOR_APP, monitorAppController.Get);
            _app.MapGet(ApiPerstUrl.API_GET_ALL_MONITOR_APP, monitorAppController.GetAll);
        }
    }
}
