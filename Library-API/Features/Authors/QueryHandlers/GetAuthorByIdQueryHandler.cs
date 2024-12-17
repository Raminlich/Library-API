using Library_API.Features.Authors.Queries;
using Library_API.Models;
using Library_API.Persistence.Repositories;
using MediatR;

namespace Library_API.Features.Authors.QueryHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(request.id);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found!");
            }
            return author;
        }
    }
}
