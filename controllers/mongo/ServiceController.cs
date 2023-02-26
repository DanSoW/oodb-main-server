using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Microsoft.AspNetCore.Mvc;
using oodb_project.models;
using oodb_project.models.Service;
using Db4objects.Db4o.Linq;
using oodb_project.controllers.predicates.Service;

namespace oodb_project.controllers.mongo
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов Service
    /// </summary>
    public class ServiceController : BaseController<ServiceModel>
    {
        public static string LOCAL_URL = "/service";

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

        public IResult create(ServiceModel model)
        {
            return Create($"{LOCAL_URL}/save", model);
        }

        public IResult update(ServiceModel model)
        {
            return Update($"{LOCAL_URL}/update", model);
        }
    }
}
