using Microsoft.AspNetCore.Mvc;
using TestApplication.Model;

namespace TestApplication.Commands.UpdateBookHandling
{
	public class UpdateBookCommand : ICommand<bool>
	{
		[FromRoute(Name = "id")]
		public string Id { get; set; }
		
		[FromBody]
		public Book Book { get; set; }
	}
}