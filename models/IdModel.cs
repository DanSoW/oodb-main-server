namespace oodb_project.models
{
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
