namespace Profile.Config
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ActionsCollectionName { get; set; } = null!;
    }
}