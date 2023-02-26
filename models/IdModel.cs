namespace oodb_project.models
{
    /// <summary>
    /// Абстрактный класс для обобщения моделей
    /// </summary>
    public abstract class IdModel
    {
        public IdModel() {}

        public IdModel(string? id)
        {
            Id = id;
        }

        public string? Id { get; set; }
    }
}
