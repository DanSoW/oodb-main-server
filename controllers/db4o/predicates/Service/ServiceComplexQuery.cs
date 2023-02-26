using Db4objects.Db4o.Query;
using oodb_project.models;


namespace oodb_project.controllers.predicates.Service
{
    /// <summary>
    /// Класс, определяющий предикат комплексного запроса
    /// </summary>
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

        /// <summary>
        /// Условие
        /// </summary>
        /// <param name="service">Экземпляр объекта ServiceModel</param>
        /// <returns>Результат выполнения условия</returns>
        public bool Match(ServiceModel service)
        {
            return service.Port == port;
        }
    }
}
