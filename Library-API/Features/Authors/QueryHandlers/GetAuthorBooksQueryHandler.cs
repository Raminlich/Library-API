using Library_API.Features.Authors.Queries;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Features.Authors.QueryHandlers
{
    public class GetAuthorBooksQueryHandler : IRequestHandler<GetAuthorBooksQuery, ICollection<Book>>
    {
        private readonly AppDbContext _dbContext;

        public GetAuthorBooksQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Book>> Handle(GetAuthorBooksQuery request, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors
                .AsNoTracking()
                .Include(o => o.Books)
                .FirstOrDefaultAsync(o => o.Id == request.id);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found!");
            }
            return author.Books;
        }
    }
}
