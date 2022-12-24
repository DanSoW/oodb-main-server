namespace oodb_project.constants.services.PerstService
{
    public class ApiPerstServiceUrl
    {
        /* Запросы на сохранение данных */
        static public string API_SAVE_HOST = "/api/db4o/host/save";

        static public string API_SAVE_ADMIN = "/api/db4o/admin/save";

        static public string API_SAVE_DATA_SOURCE = "/api/db4o/data-source/save";

        static public string API_SAVE_SERVICE = "/api/db4o/service/save";

        static public string API_SAVE_HOST_SERVICE = "/api/db4o/host-service/save";

        static public string API_SAVE_MONITOR_APP = "/api/db4o/monitor-app/save";

        /* Запросы на получение данных */
        static public string GET = "/get/{id}";
        static public string GET_ALL = "/get/all";

        /* Запрос на изменение данных */
        static public string API_UPDATE_HOST = "/api/db4o/host/update";

        static public string API_UPDATE_ADMIN = "/api/db4o/admin/update";

        static public string API_UPDATE_DATA_SOURCE = "/api/db4o/data-source/update";

        static public string API_UPDATE_SERVICE = "/api/db4o/service/update";

        static public string API_UPDATE_HOST_SERVICE = "/api/db4o/host-service/update";

        static public string API_UPDATE_MONITOR_APP = "/api/db4o/monitor-app/update";

        /* Запрос на удаление */
        static public string API_DELETE_HOST = "/api/db4o/host/delete/{id}";

        static public string API_DELETE_ADMIN = "/api/db4o/admin/delete/{id}";

        static public string API_DELETE_DATA_SOURCE = "/api/db4o/data-source/delete/{id}";

        static public string API_DELETE_SERVICE = "/api/db4o/service/delete/{id}";

        static public string API_DELETE_HOST_SERVICE = "/api/db4o/host-service/delete/{id}";

        static public string API_DELETE_MONITOR_APP = "/api/db4o/monitor-app/delete/{id}";
    }
}
