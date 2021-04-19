using System.Threading;
using System.Threading.Tasks;
using TestApplication.Repositories;

namespace TestApplication.Commands.DeleteBookHandling
{
	public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand, bool>
	{
		private readonly BooksRepository booksRepository;

		public DeleteBookCommandHandler(BooksRepository booksRepository)
		{
			this.booksRepository = booksRepository;
		}

		public Task<bool> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
		{
			return Task.FromResult(booksRepository.TryDeleteBook(command.Id, cancellationToken));
		}
	}
}