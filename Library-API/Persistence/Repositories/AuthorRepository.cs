using Library_API.Models;
using Library_API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Persistence.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthorRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> GetAuthorBooksAsync(Guid id)
        {
            var author = await _dbContext.Authors
                .AsNoTracking()
                .Include(o => o.Books)
                .FirstOrDefaultAsync(o => o.Id == id);
            return author;
        }
    }
}
