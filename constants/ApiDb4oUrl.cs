namespace oodb_project.constants
{
    public class ApiDb4oUrl
    {
        /* Запросы на сохранение данных */
        static public string API_SAVE_HOST              = "/api/db4o/host/save";

        static public string API_SAVE_ADMIN             = "/api/db4o/admin/save";

        static public string API_SAVE_DATA_SOURCE       = "/api/db4o/data-source/save";

        static public string API_SAVE_SERVICE           = "/api/db4o/service/save";

        static public string API_SAVE_HOST_SERVICE      = "/api/db4o/host-service/save";

        static public string API_SAVE_MONITOR_APP       = "/api/db4o/monitor-app/save";

        /* Запросы на получение данных */
        static public string API_GET_HOST               = "/api/db4o/host/get/{id}";
        static public string API_GET_ALL_HOST           = "/api/db4o/host/get/all";
        static public string API_COMPLEX_HOST           = "/api/db4o/host/get/complex";
        static public string API_COMPLEX_LINQ_HOST      = "/api/db4o/host/get/complex-linq";

        static public string API_GET_ADMIN              = "/api/db4o/admin/get/{id}";
        static public string API_GET_ALL_ADMIN          = "/api/db4o/admin/get/all";

        static public string API_GET_DATA_SOURCE        = "/api/db4o/data-source/get/{id}";
        static public string API_GET_ALL_DATA_SOURCE    = "/api/db4o/data-source/get/all";

        static public string API_GET_SERVICE            = "/api/db4o/service/get/{id}";
        static public string API_GET_ALL_SERVICE        = "/api/db4o/service/get/all";
        static public string API_COMPLEX_SERVICE        = "/api/db4o/service/get/all/complex";
        static public string API_COMPLEX_LINQ_SERVICE   = "/api/db4o/service/get/all/complex-linq";

        static public string API_GET_HOST_SERVICE       = "/api/db4o/host-service/get/{id}";
        static public string API_GET_ALL_HOST_SERVICE   = "/api/db4o/host-service/get/all";

        static public string API_GET_MONITOR_APP        = "/api/db4o/monitor-app/get/{id}";
        static public string API_GET_ALL_MONITOR_APP    = "/api/db4o/monitor-app/get/all";
        static public string API_GET_SODA_MONITOR_APP   = "/api/db4o/monitor-app/get/soda";

        /* Запрос на изменение данных */
        static public string API_UPDATE_HOST            = "/api/db4o/host/update";

        static public string API_UPDATE_ADMIN           = "/api/db4o/admin/update";

        static public string API_UPDATE_DATA_SOURCE     = "/api/db4o/data-source/update";

        static public string API_UPDATE_SERVICE         = "/api/db4o/service/update";

        static public string API_UPDATE_HOST_SERVICE    = "/api/db4o/host-service/update";

        static public string API_UPDATE_MONITOR_APP     = "/api/db4o/monitor-app/update";

        /* Запрос на удаление */
        static public string API_DELETE_HOST            = "/api/db4o/host/delete/{id}";

        static public string API_DELETE_ADMIN           = "/api/db4o/admin/delete/{id}";

        static public string API_DELETE_DATA_SOURCE     = "/api/db4o/data-source/delete/{id}";

        static public string API_DELETE_SERVICE         = "/api/db4o/service/delete/{id}";

        static public string API_DELETE_HOST_SERVICE    = "/api/db4o/host-service/delete/{id}";

        static public string API_DELETE_MONITOR_APP     = "/api/db4o/monitor-app/delete/{id}";
    }
}
