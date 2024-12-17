using Library_API.Models;
using MediatR;

namespace Library_API.Features.Books.Queries
{
    public record GetBookByIdQuery (Guid id): IRequest<Book>;
}
