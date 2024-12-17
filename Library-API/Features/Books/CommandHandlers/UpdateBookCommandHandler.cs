using AutoMapper;
using Library_API.Features.Books.Commands;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Features.Books.CommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly AppDbContext _dbContext;

        public UpdateBookCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(o => o.Id == request.id);
            if(book == null)
            {
                throw new KeyNotFoundException("Book not found!");
            }
            book.AuthorId = request.authorId;
            book.Title = request.title;
            book.PublishedYear = request.publishedYear;
            return book;
        }
    }
}
