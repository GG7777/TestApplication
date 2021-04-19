using System.Threading;
using System.Threading.Tasks;
using TestApplication.Repositories;

namespace TestApplication.Commands.AddBookHandling
{
	public class AddBookCommandHandler : ICommandHandler<AddBookCommand, bool>
	{
		private readonly BooksRepository booksRepository;

		public AddBookCommandHandler(BooksRepository booksRepository)
		{
			this.booksRepository = booksRepository;
		}

		public Task<bool> Handle(AddBookCommand command, CancellationToken cancellationToken)
		{
			return Task.FromResult(booksRepository.TryAddBook(command.Book, cancellationToken));
		}
	}
}