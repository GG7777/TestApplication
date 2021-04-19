using System.Threading;
using System.Threading.Tasks;
using TestApplication.Model;
using TestApplication.Repositories;

namespace TestApplication.Queries.GetBookHandling
{
	public class GetBookQueryHandler : IQueryHandler<GetBookQuery, Book>
	{
		private readonly BooksRepository booksRepository;

		public GetBookQueryHandler(BooksRepository booksRepository)
		{
			this.booksRepository = booksRepository;
		}

		public Task<Book> Handle(GetBookQuery query, CancellationToken cancellationToken)
		{
			return Task.FromResult(booksRepository.TryGetBook(query.Id, cancellationToken));
		}
	}
}