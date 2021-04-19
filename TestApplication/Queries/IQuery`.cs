using MediatR;

namespace TestApplication.Queries
{
	public interface IQuery<out T> : IRequest<T>
	{
	}
}