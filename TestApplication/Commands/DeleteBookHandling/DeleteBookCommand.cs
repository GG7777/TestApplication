using Microsoft.AspNetCore.Mvc;

namespace TestApplication.Commands.DeleteBookHandling
{
	public class DeleteBookCommand : ICommand<bool>
	{
		[FromRoute(Name = "id")]
		public string Id { get; set; }
	}
}