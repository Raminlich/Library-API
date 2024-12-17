using Library_API.Features.Books.Queries;
using Library_API.Models;
using Library_API.Persistence.Repositories;
using MediatR;

namespace Library_API.Features.Books.QueryHandlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.id);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found!");
            }
            return book;
        }
    }
}
