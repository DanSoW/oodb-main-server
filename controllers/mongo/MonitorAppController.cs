using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Microsoft.AspNetCore.Mvc;
using oodb_project.models;
using oodb_project.models.MonitorApp;

namespace oodb_project.controllers.mongo
{
    public class MonitorAppController : BaseController<MonitorAppModel>
    {
        public static string LOCAL_URL = "/monitor-app";

        public IResult get(string id)
        {
            return Get($"{LOCAL_URL}/get", id);
        }

        public IResult getAll()
        {
            return GetAll($"{LOCAL_URL}/get/all");
        }

        public IResult delete(string id)
        {
            return Delete($"{LOCAL_URL}/delete", id);
        }

        public IResult create(MonitorAppModel model)
        {
            return Create($"{LOCAL_URL}/save", model);
        }

        public IResult update(MonitorAppModel model)
        {
            return Update($"{LOCAL_URL}/update", model);
        }
    }
}
