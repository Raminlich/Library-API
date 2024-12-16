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

        public AuthorController(ISender sender,IMapper mapper)
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

        [HttpPost]
        public async Task<ActionResult> CreateAuthor(CreateAuthorCommand authorCommand)
        {
            var guid = await _sender.Send(authorCommand);
            return Ok(guid);
        }


    }
}
