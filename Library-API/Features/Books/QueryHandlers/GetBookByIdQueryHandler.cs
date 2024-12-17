using Library_API.Features.Books.Queries;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Features.Books.QueryHandlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly AppDbContext _dbContext;

        public GetBookByIdQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(o => o.Id == request.id);
            if(book == null)
            {
                throw new KeyNotFoundException("Book not found!");
            }
            return book;
        }
    }
}
