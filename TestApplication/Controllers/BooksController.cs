using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Commands.AddBookHandling;
using TestApplication.Commands.DeleteBookHandling;
using TestApplication.Commands.UpdateBookHandling;
using TestApplication.Queries.GetBookHandling;

namespace TestApplication.Controllers
{
	[Route("/api/v1/books")]
	public class BooksController : ControllerBase
	{
		private readonly IMediator mediator;

		public BooksController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBook(GetBookQuery getBookQuery)
		{
			var book = await mediator.Send(getBookQuery, HttpContext.RequestAborted).ConfigureAwait(false);
			return book != null ? Ok(book) : (IActionResult) NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> AddBook(AddBookCommand addBookCommand)
		{
			var isSuccess = await mediator.Send(addBookCommand, HttpContext.RequestAborted).ConfigureAwait(false);
			return isSuccess ? Ok() : (IActionResult) BadRequest();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBook(UpdateBookCommand updateBookCommand)
		{
			var isSuccess = await mediator.Send(updateBookCommand, HttpContext.RequestAborted).ConfigureAwait(false);
			return isSuccess ? Ok() : (IActionResult) NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBook(DeleteBookCommand deleteBookCommand)
		{
			var isSuccess = await mediator.Send(deleteBookCommand, HttpContext.RequestAborted).ConfigureAwait(false);
			return isSuccess ? Ok() : (IActionResult) NotFound();
		}
	}
}