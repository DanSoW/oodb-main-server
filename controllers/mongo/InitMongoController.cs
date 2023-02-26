using oodb_project.constants;

namespace oodb_project.controllers.mongo
{
    /// <summary>
    /// Класс, содержащий методы для инициализации маршрутов в рамках работы с базой данных MongoDB
    /// </summary>
    public class InitMongoController
    {
        private static WebApplication? _app;
        public InitMongoController(WebApplication app)
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
            /* CRUD операции для HostModel */
            /* ----------- */
            var hostController = new HostController();

            _app.MapPost(ApiMongoUrl.API_SAVE_HOST, hostController.create);
            _app.MapPost(ApiMongoUrl.API_UPDATE_HOST, hostController.update);
            _app.MapPost(ApiMongoUrl.API_DELETE_HOST, hostController.delete);
            _app.MapGet(ApiMongoUrl.API_GET_HOST, hostController.get);
            _app.MapGet(ApiMongoUrl.API_GET_ALL_HOST, hostController.getAll);

            /* ----------- */
            /* CRUD операции для Admin */
            /* ----------- */
            var adminController = new AdminController();

            _app.MapPost(ApiMongoUrl.API_SAVE_ADMIN, adminController.create);
            _app.MapPost(ApiMongoUrl.API_UPDATE_ADMIN, adminController.update);
            _app.MapPost(ApiMongoUrl.API_DELETE_ADMIN, adminController.delete);
            _app.MapGet(ApiMongoUrl.API_GET_ADMIN, adminController.get);
            _app.MapGet(ApiMongoUrl.API_GET_ALL_ADMIN, adminController.getAll);

            /* ----------- */
            /* CRUD операции для DataSource */
            /* ----------- */
            var dataSourceController = new DataSourceController();

            _app.MapPost(ApiMongoUrl.API_SAVE_DATA_SOURCE, dataSourceController.create);
            _app.MapPost(ApiMongoUrl.API_UPDATE_DATA_SOURCE, dataSourceController.update);
            _app.MapPost(ApiMongoUrl.API_DELETE_DATA_SOURCE, dataSourceController.delete);
            _app.MapGet(ApiMongoUrl.API_GET_DATA_SOURCE, dataSourceController.get);
            _app.MapGet(ApiMongoUrl.API_GET_ALL_DATA_SOURCE, dataSourceController.getAll);

            /* ----------- */
            /* CRUD операции для Service */
            /* ----------- */
            var serviceController = new ServiceController();

            _app.MapPost(ApiMongoUrl.API_SAVE_SERVICE, serviceController.create);
            _app.MapPost(ApiMongoUrl.API_UPDATE_SERVICE, serviceController.update);
            _app.MapPost(ApiMongoUrl.API_DELETE_SERVICE, serviceController.delete);
            _app.MapGet(ApiMongoUrl.API_GET_SERVICE, serviceController.get);
            _app.MapGet(ApiMongoUrl.API_GET_ALL_SERVICE, serviceController.getAll);

            /* ----------- */
            /* CRUD операции для HostService */
            /* ----------- */
            var hostServiceController = new HostServiceController();

            _app.MapPost(ApiMongoUrl.API_SAVE_HOST_SERVICE, hostServiceController.create);
            _app.MapPost(ApiMongoUrl.API_UPDATE_HOST_SERVICE, hostServiceController.update);
            _app.MapPost(ApiMongoUrl.API_DELETE_HOST_SERVICE, hostServiceController.delete);
            _app.MapGet(ApiMongoUrl.API_GET_HOST_SERVICE, hostServiceController.get);
            _app.MapGet(ApiMongoUrl.API_GET_ALL_HOST_SERVICE, hostServiceController.getAll);

            /* ----------- */
            /* CRUD операции для MonitorApp */
            /* ----------- */
            var monitorAppController = new MonitorAppController();

            _app.MapPost(ApiMongoUrl.API_SAVE_MONITOR_APP, monitorAppController.create);
            _app.MapPost(ApiMongoUrl.API_UPDATE_MONITOR_APP, monitorAppController.update);
            _app.MapPost(ApiMongoUrl.API_DELETE_MONITOR_APP, monitorAppController.delete);
            _app.MapGet(ApiMongoUrl.API_GET_MONITOR_APP, monitorAppController.get);
            _app.MapGet(ApiMongoUrl.API_GET_ALL_MONITOR_APP, monitorAppController.getAll);
        }
    }
}
