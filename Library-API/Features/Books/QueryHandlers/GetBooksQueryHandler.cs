using Library_API.Features.Books.Queries;
using Library_API.Models;
using Library_API.Persistence.Repositories;
using MediatR;

namespace Library_API.Features.Books.QueryHandlers
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, ICollection<Book>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBooksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _unitOfWork.Books.GetAllAsync();
            return books.ToArray();
        }
    }
}
