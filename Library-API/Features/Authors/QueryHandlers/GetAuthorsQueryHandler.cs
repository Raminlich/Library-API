using Library_API.Features.Authors.Queries;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Features.Authors.QueryHandlers
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, ICollection<Author>>
    {
        private readonly AppDbContext _dbContext;

        public GetAuthorsQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _dbContext.Authors.AsNoTracking().ToArrayAsync();
            return authors;
        }
    }
}
