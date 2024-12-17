using AutoMapper;
using Library_API.DTOs;
using Library_API.Features.Books.Commands;
using Library_API.Features.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public BookController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<BookDto>>> GetBooks()
        {
            var books = await _sender.Send(new GetBooksQuery());
            var booksDto = _mapper.Map<ICollection<BookDto>>(books);
            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            var book = await _sender.Send(new GetBookByIdQuery(id));
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook(CreateBookCommand bookCommand)
        {
            var guid = await _sender.Send(bookCommand);
            return Ok(guid);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> UpdateBook(UpdateBookCommand updateBookCommand)
        {
            var book = await _sender.Send(updateBookCommand);
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }


    }
}
