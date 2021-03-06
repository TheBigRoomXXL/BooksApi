namespace BooksApi.Models
{
    public class BooksDatabaseSettings : IBooksDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string TagsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBooksDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string TagsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}