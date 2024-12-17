using Library_API.Features.Authors.Queries;
using Library_API.Models;
using Library_API.Persistence.Repositories;
using MediatR;

namespace Library_API.Features.Authors.QueryHandlers
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, ICollection<Author>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAuthorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            return authors.ToArray();
        }
    }
}
