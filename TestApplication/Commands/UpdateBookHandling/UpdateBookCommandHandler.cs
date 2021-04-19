using System.Threading;
using System.Threading.Tasks;
using TestApplication.Repositories;

namespace TestApplication.Commands.UpdateBookHandling
{
	public class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand, bool>
	{
		private readonly BooksRepository booksRepository;

		public UpdateBookCommandHandler(BooksRepository booksRepository)
		{
			this.booksRepository = booksRepository;
		}

		public Task<bool> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
		{
			return Task.FromResult(booksRepository.TryUpdateBook(command.Id, command.Book, cancellationToken));
		}
	}
}