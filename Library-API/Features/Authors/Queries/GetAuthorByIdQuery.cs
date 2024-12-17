using Library_API.Models;
using MediatR;

namespace Library_API.Features.Authors.Queries
{
    public record GetAuthorByIdQuery(Guid id) : IRequest<Author>;
}
