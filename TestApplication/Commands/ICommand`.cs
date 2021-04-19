using MediatR;

namespace TestApplication.Commands
{
	public interface ICommand<out T> : IRequest<T>
	{
	}
}