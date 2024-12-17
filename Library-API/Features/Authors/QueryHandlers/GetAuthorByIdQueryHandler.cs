using Library_API.Features.Authors.Queries;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Features.Authors.QueryHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly AppDbContext _dbContext;

        public GetAuthorByIdQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(o => o.Id == request.id);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found!");
            }
            return author;
        }
    }
}
