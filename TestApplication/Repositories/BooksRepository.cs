using System.Collections.Generic;
using System.Threading;
using TestApplication.Model;

namespace TestApplication.Repositories
{
	public class BooksRepository
	{
		private readonly Dictionary<string, Book> books = new Dictionary<string, Book>();
		
		public Book TryGetBook(string id, CancellationToken _)
		{
			lock (books)
				return books.TryGetValue(id, out var book) ? book : null;
		}

		public bool TryAddBook(Book book, CancellationToken _)
		{
			lock (books)
			{
				if (books.ContainsKey(book.Id))
					return false;
				books[book.Id] = book;
				return true;
			}
		}

		public bool TryUpdateBook(string id, Book book, CancellationToken _)
		{
			lock (books)
			{
				if (!books.ContainsKey(id))
					return false;
				book.Id = id;
				books[id] = book;
				return true;
			}
		}

		public bool TryDeleteBook(string id, in CancellationToken _)
		{
			lock (books)
				return books.Remove(id);
		}
	}
}