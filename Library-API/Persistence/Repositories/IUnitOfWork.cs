using Library_API.Models;

namespace Library_API.Persistence.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IRepository<Book> Books { get; }
        Task SaveAsync();
    }
}
