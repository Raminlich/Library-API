using Library_API.Models;

namespace Library_API.Persistence.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetAuthorBooksAsync(Guid id);
    }
}
