namespace Homework2.Models.Configuration
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
        public ProductsRepositoryConfig ProductsRepository { get; set; }
    }
}