using Library_API.Features.Authors.Commands;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using Library_API.Persistence.Repositories;
using MediatR;

namespace Library_API.Features.Authors.CommandHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand,Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.name,
            };
            await _unitOfWork.Authors.AddAsync(author);
            await _unitOfWork.SaveAsync();
            return author.Id;
        }
    }
}
