using AutoMapper;
using Library_API.DTOs;
using Library_API.Features.Authors.Commands;
using Library_API.Features.Authors.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public AuthorController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<AuthorDto>>> GetAllAuthors()
        {
            var authors = await _sender.Send(new GetAuthorsQuery());
            var authorsDto = _mapper.Map<ICollection<AuthorDto>>(authors);
            return Ok(authorsDto);
        }

        [HttpGet("AuthorBooks/{id}")]
        public async Task<ActionResult<ICollection<BookDto>>> GetAuthorBooks(Guid id)
        {
            var books = await _sender.Send(new GetAuthorBooksQuery(id));
            var booksDto = _mapper.Map<ICollection<BookDto>>(books);
            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(Guid id)
        {
            var author = await _sender.Send(new GetAuthorByIdQuery(id));
            var authorDto = _mapper.Map<AuthorDto>(author);
            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor(CreateAuthorCommand authorCommand)
        {
            var guid = await _sender.Send(authorCommand);
            return Ok(guid);
        }

        [HttpPut]
        public async Task<ActionResult<AuthorDto>> UpdateAuthor(Guid id, [FromBody] AuthorUpdateDto body)
        {
            var updateAuthor = new UpdateAuthorCommand(id, body.Name);
            var author = await _sender.Send(updateAuthor);
            var authorDto = _mapper.Map<AuthorDto>(author);
            return Ok(author);
        }




    }
}
