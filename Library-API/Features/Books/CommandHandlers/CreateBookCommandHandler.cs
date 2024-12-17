using Library_API.Features.Books.Commands;
using Library_API.Models;
using Library_API.Persistence.Repositories;
using MediatR;

namespace Library_API.Features.Books.CommandHandlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.title,
                AuthorId = request.authorId,
                PublishedYear = request.publishedYear,
            };
            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveAsync();
            return book.Id;
        }
    }
}
