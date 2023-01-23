using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using oodb_project.models;

namespace oodb_project.controllers.mongo
{
    public class DataSourceController : BaseController<DataSourceModel>
    {
        public static string LOCAL_URL = "/data-source";

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

        public IResult create(DataSourceModel model)
        {
            return Create($"{LOCAL_URL}/save", model);
        }

        public IResult update(DataSourceModel model)
        {
            return Update($"{LOCAL_URL}/update", model);
        }
    }
}
