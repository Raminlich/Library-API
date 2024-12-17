using Library_API.Models;
using MediatR;

namespace Library_API.Features.Authors.Queries
{
    public record GetAuthorBooksQuery(Guid id) : IRequest<ICollection<Book>>;
}
