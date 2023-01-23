namespace oodb_project.models
{
    /// <summary>
    /// Модель, характеризующая отдельный сервис (микросервис)
    /// </summary>
    public class ServiceModel : IdModel
    {
        public ServiceModel() : base()
        {
        }

        public ServiceModel(string? id, string? name, int port, int timeUpdate, string? dataSourceId) : base(id)
        {
            Name = name;
            Port = port;
            TimeUpdate = timeUpdate;
            DataSourceId = dataSourceId;
        }

        public string? Name { get; set; }
        public int Port { get; set; }
        public int TimeUpdate { get; set; }
        public string? DataSourceId { get; set; }
    }
}
