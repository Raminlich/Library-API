using Library_API.Features.Authors.Queries;
using Library_API.Models;
using Library_API.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Features.Authors.QueryHandlers
{
    public class GetAuthorBooksQueryHandler : IRequestHandler<GetAuthorBooksQuery, ICollection<Book>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAuthorBooksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Book>> Handle(GetAuthorBooksQuery request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetAuthorBooksAsync(request.id);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found!");
            }
            return author.Books;
        }
    }
}
