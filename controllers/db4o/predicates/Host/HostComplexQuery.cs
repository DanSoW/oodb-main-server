using Db4objects.Db4o.Query;
using oodb_project.models;

namespace oodb_project.controllers.predicates.Host
{
    /// <summary>
    /// Класс, определяющий предикат для комплексного запроса db4o
    /// </summary>
    public class HostComplexQuery : Predicate
    {
        public HostComplexQuery()
        {
        }

        public HostComplexQuery(string? iPv4, string? system)
        {
            IPv4 = iPv4;
            System = system;
        }

        public string? IPv4 { get; set; }
        public string? System { get; set; }

        /// <summary>
        /// Условие
        /// </summary>
        /// <param name="host">Экземпляр объекта HostModel</param>
        /// <returns>Результат выполнения условия</returns>
        public bool Match(HostModel host)
        {
            return host.IPv4 == IPv4 && host.System == System;
        }
    }
}
