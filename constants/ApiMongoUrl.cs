namespace oodb_project.constants
{
    public class ApiMongoUrl
    {
        /* Запросы на сохранение данных */
        static public string API_SAVE_HOST = "/api/mongo/host/save";
        static public string API_SAVE_ADMIN = "/api/mongo/admin/save";
        static public string API_SAVE_DATA_SOURCE = "/api/mongo/data-source/save";
        static public string API_SAVE_SERVICE = "/api/mongo/service/save";
        static public string API_SAVE_HOST_SERVICE = "/api/mongo/host-service/save";
        static public string API_SAVE_MONITOR_APP = "/api/mongo/monitor-app/save";

        /* Запросы на получение данных */
        static public string API_GET_HOST = "/api/mongo/host/get/{id}";
        static public string API_GET_ALL_HOST = "/api/mongo/host/get/all";
        static public string API_GET_ADMIN = "/api/mongo/admin/get/{id}";
        static public string API_GET_ALL_ADMIN = "/api/mongo/admin/get/all";
        static public string API_GET_DATA_SOURCE = "/api/mongo/data-source/get/{id}";
        static public string API_GET_ALL_DATA_SOURCE = "/api/mongo/data-source/get/all";
        static public string API_GET_SERVICE = "/api/mongo/service/get/{id}";
        static public string API_GET_ALL_SERVICE = "/api/mongo/service/get/all";
        static public string API_GET_HOST_SERVICE = "/api/mongo/host-service/get/{id}";
        static public string API_GET_ALL_HOST_SERVICE = "/api/mongo/host-service/get/all";
        static public string API_GET_MONITOR_APP = "/api/mongo/monitor-app/get/{id}";
        static public string API_GET_ALL_MONITOR_APP = "/api/mongo/monitor-app/get/all";

        /* Запрос на изменение данных */
        static public string API_UPDATE_HOST = "/api/mongo/host/update";
        static public string API_UPDATE_ADMIN = "/api/mongo/admin/update";
        static public string API_UPDATE_DATA_SOURCE = "/api/mongo/data-source/update";
        static public string API_UPDATE_SERVICE = "/api/mongo/service/update";
        static public string API_UPDATE_HOST_SERVICE = "/api/mongo/host-service/update";
        static public string API_UPDATE_MONITOR_APP = "/api/mongo/monitor-app/update";

        /* Запрос на удаление */
        static public string API_DELETE_HOST = "/api/mongo/host/delete/{id}";
        static public string API_DELETE_ADMIN = "/api/mongo/admin/delete/{id}";
        static public string API_DELETE_DATA_SOURCE = "/api/mongo/data-source/delete/{id}";
        static public string API_DELETE_SERVICE = "/api/mongo/service/delete/{id}";
        static public string API_DELETE_HOST_SERVICE = "/api/mongo/host-service/delete/{id}";
        static public string API_DELETE_MONITOR_APP = "/api/mongo/monitor-app/delete/{id}";
    }
}
