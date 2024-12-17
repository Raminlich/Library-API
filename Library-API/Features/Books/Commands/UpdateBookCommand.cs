using Library_API.Models;
using MediatR;

namespace Library_API.Features.Books.Commands
{
    public record UpdateBookCommand(Guid id, string title, Guid authorId, int publishedYear) : IRequest<Book>;
}
