using Library_API.Models;
using MediatR;

namespace Library_API.Features.Books.Queries
{
    public record GetBooksQuery : IRequest<ICollection<Book>>;
}
