using Microsoft.AspNetCore.Mvc;
using TestApplication.Model;

namespace TestApplication.Queries.GetBookHandling
{
	public class GetBookQuery : IQuery<Book>
	{
		[FromRoute(Name = "id")]
		public string Id { get; set; }
	}
}