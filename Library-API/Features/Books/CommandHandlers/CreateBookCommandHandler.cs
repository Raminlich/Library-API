using Library_API.Features.Books.Commands;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using MediatR;

namespace Library_API.Features.Books.CommandHandlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly AppDbContext _dbContext;

        public CreateBookCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.title,
                AuthorId = request.authorId,
                PublishedYear = request.publishedYear,
            };
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book.Id;
        }
    }
}
