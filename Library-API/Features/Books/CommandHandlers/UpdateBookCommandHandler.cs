using Library_API.Features.Books.Commands;
using Library_API.Models;
using Library_API.Persistence.Repositories;
using MediatR;

namespace Library_API.Features.Books.CommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.id);
            var author = await _unitOfWork.Authors.GetByIdAsync(request.authorId);
            if (book == null || author == null)
            {
                throw new KeyNotFoundException("Book or Author not found!");
            }
            book.AuthorId = request.authorId;
            book.Title = request.title;
            book.PublishedYear = request.publishedYear;
            await _unitOfWork.SaveAsync();
            return book;
        }
    }
}
