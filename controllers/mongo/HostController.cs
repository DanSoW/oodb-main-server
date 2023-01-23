using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Microsoft.AspNetCore.Mvc;
using oodb_project.controllers.predicates.Host;
using oodb_project.models;
using oodb_project.models.Host;

namespace oodb_project.controllers.mongo
{
    public class HostController : BaseController<HostModel>
    {
        public static string LOCAL_URL = "/host";

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

        public IResult create(HostModel model)
        {
            return Create($"{LOCAL_URL}/save", model);
        }

        public IResult update(HostModel model)
        {
            return Update($"{LOCAL_URL}/update", model);
        }
    }
}
