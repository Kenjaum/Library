using Library.Application.Commands.CreateBook;
using Library.Application.Commands.UpdateBook;
using Library.Application.Queries;
using Library.Application.Queries.GetAllBooks;
using Library.Application.Queries.GetAllLoans;
using Library.Application.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/v1/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _mediator.Send(new GetAllLoansQuery());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost, Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            if (command.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
