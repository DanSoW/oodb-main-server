namespace oodb_project.models
{
    /// <summary>
    /// Модель, характеризующая источник данных для сервиса
    /// </summary>
    public class DataSourceModel : IdModel
    {
        public DataSourceModel() : base()
        {
        }

        public DataSourceModel(string? id, string? name, string? url) : base(id)
        {
            Name = name;
            Url = url;
        }

        public string? Name { get; set; }
        public string? Url { get; set; }
    }
}
