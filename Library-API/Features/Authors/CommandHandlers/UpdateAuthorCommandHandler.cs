using Library_API.Features.Authors.Commands;
using Library_API.Models;
using Library_API.Persistence.Repositories;
using MediatR;

namespace Library_API.Features.Authors.CommandHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _unitOfWork.Authors.GetByIdAsync(request.id).Result;
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found!");
            }
            author.Name = request.name;
            await _unitOfWork.SaveAsync();
            return author;
        }
    }
}
