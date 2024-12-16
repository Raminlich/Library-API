using MediatR;

namespace Library_API.Features.Books.Commands
{
    public record CreateBookCommand(string title,Guid authorId,int publishedYear) : IRequest<Guid>;
}
