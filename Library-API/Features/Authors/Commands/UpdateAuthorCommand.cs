using Library_API.Models;
using MediatR;

namespace Library_API.Features.Authors.Commands
{
    public record UpdateAuthorCommand(Guid id, string name) : IRequest<Author>;
}
