using MediatR;

namespace Library_API.Features.Authors.Commands
{
    public record CreateAuthorCommand(string name) : IRequest;
}
