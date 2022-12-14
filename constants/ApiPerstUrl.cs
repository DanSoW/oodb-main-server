namespace oodb_project.constants
{
    public class ApiPerstUrl
    {
        /* Запросы на сохранение данных */
        static public string API_SAVE_HOST              = "/api/perst/host/save";

        static public string API_SAVE_ADMIN             = "/api/perst/admin/save";

        static public string API_SAVE_DATA_SOURCE       = "/api/perst/data-source/save";

        static public string API_SAVE_SERVICE           = "/api/perst/service/save";

        static public string API_SAVE_HOST_SERVICE      = "/api/perst/host-service/save";

        static public string API_SAVE_MONITOR_APP       = "/api/perst/monitor-app/save";

        /* Запросы на получение данных */
        static public string API_GET_HOST               = "/api/perst/host/get/{id}";
        static public string API_GET_ALL_HOST           = "/api/perst/host/get/all";
        static public string API_COMPLEX_HOST           = "/api/perst/host/get/complex";
        static public string API_COMPLEX_LINQ_HOST      = "/api/perst/host/get/complex-linq";

        static public string API_GET_ADMIN              = "/api/perst/admin/get/{id}";
        static public string API_GET_ALL_ADMIN          = "/api/perst/admin/get/all";

        static public string API_GET_DATA_SOURCE        = "/api/perst/data-source/get/{id}";
        static public string API_GET_ALL_DATA_SOURCE    = "/api/perst/data-source/get/all";

        static public string API_GET_SERVICE            = "/api/perst/service/get/{id}";
        static public string API_GET_ALL_SERVICE        = "/api/perst/service/get/all";
        static public string API_COMPLEX_SERVICE        = "/api/perst/service/get/all/complex";
        static public string API_COMPLEX_LINQ_SERVICE   = "/api/perst/service/get/all/complex-linq";

        static public string API_GET_HOST_SERVICE       = "/api/perst/host-service/get/{id}";
        static public string API_GET_ALL_HOST_SERVICE   = "/api/perst/host-service/get/all";

        static public string API_GET_MONITOR_APP        = "/api/perst/monitor-app/get/{id}";
        static public string API_GET_ALL_MONITOR_APP    = "/api/perst/monitor-app/get/all";
        static public string API_GET_SODA_MONITOR_APP   = "/api/perst/monitor-app/get/soda";

        /* Запрос на изменение данных */
        static public string API_UPDATE_HOST            = "/api/perst/host/update";

        static public string API_UPDATE_ADMIN           = "/api/perst/admin/update";

        static public string API_UPDATE_DATA_SOURCE     = "/api/perst/data-source/update";

        static public string API_UPDATE_SERVICE         = "/api/perst/service/update";

        static public string API_UPDATE_HOST_SERVICE    = "/api/perst/host-service/update";

        static public string API_UPDATE_MONITOR_APP     = "/api/perst/monitor-app/update";

        /* Запрос на удаление */
        static public string API_DELETE_HOST            = "/api/perst/host/delete/{id}";

        static public string API_DELETE_ADMIN           = "/api/perst/admin/delete/{id}";

        static public string API_DELETE_DATA_SOURCE     = "/api/perst/data-source/delete/{id}";

        static public string API_DELETE_SERVICE         = "/api/perst/service/delete/{id}";

        static public string API_DELETE_HOST_SERVICE    = "/api/perst/host-service/delete/{id}";

        static public string API_DELETE_MONITOR_APP     = "/api/perst/monitor-app/delete/{id}";
    }
}
