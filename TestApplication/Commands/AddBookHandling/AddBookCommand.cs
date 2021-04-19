using Microsoft.AspNetCore.Mvc;
using TestApplication.Model;

namespace TestApplication.Commands.AddBookHandling
{
	public class AddBookCommand : ICommand<bool>
	{
		[FromBody]
		public Book Book { get; set; }
	}
}