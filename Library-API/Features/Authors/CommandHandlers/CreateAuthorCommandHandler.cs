using Library_API.Features.Authors.Commands;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using MediatR;

namespace Library_API.Features.Authors.CommandHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly AppDbContext _dbContext;

        public CreateAuthorCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.name,
            };
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}
