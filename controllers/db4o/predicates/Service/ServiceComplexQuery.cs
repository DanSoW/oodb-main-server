using Db4objects.Db4o.Query;
using oodb_project.models;


namespace oodb_project.controllers.predicates.Service
{
    public class ServiceComplexQuery : Predicate
    {
        public ServiceComplexQuery()
        {
        }

        public ServiceComplexQuery(int? port)
        {
            this.port = port;
        }

        public int? port { get; set; }

        public bool Match(ServiceModel service)
        {
            return service.Port == port;
        }
    }
}
