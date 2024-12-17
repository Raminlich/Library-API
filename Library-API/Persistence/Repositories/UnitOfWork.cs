using Library_API.Models;
using Library_API.Persistence.Contexts;

namespace Library_API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public IAuthorRepository Authors { get; private set; }

        public IRepository<Book> Books { get; private set; }


        public UnitOfWork(AppDbContext dbContext, IAuthorRepository authorRepository)
        {
            _dbContext = dbContext;
            Books = new Repository<Book>(_dbContext);
            Authors = authorRepository;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
