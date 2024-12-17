using Library_API.Features.Authors.Commands;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using MediatR;

namespace Library_API.Features.Authors.CommandHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly AppDbContext _dbContext;

        public UpdateAuthorCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _dbContext.Authors.FirstOrDefault(o => o.Id == request.id);
            if(author == null)
            {
                throw new KeyNotFoundException("Author not found!");
            }
            author.Name = request.name;
            await _dbContext.SaveChangesAsync();
            return author;
        }
    }
}
