using Library_API.Models;
using MediatR;

namespace Library_API.Features.Authors.Queries
{
    public record GetAuthorsQuery : IRequest<ICollection<Author>>;
}
