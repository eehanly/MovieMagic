
namespace MovieMagic.Models;

    public class MovieDatabaseSettings : IMovieDatabaseSettings
    {
        public string MovieCollectionName { get; set;} =null!;
        public string ConnectionString { get; set;} = null!;
        public string DatabaseName { get; set;} = null!;
    }
    public interface IMovieDatabaseSettings
    {
        string MovieCollectionName { get; set;}
        string ConnectionString { get; set;}
        string DatabaseName { get; set;}
    }
