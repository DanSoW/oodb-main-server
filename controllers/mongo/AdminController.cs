using Db4objects.Db4o;
using oodb_project.models;

namespace oodb_project.controllers.mongo
{
    /// <summary>
    /// Класс определяющий контроллеры для коллекции объектов Admin
    /// </summary>
    public class AdminController : BaseController<AdminModel>
    {
        public static string LOCAL_URL = "/admin";

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

        public IResult create(AdminModel model)
        {
            return Create($"{LOCAL_URL}/save", model);
        }

        public IResult update(AdminModel model)
        {
            return Update($"{LOCAL_URL}/update", model);
        }
    }
}
