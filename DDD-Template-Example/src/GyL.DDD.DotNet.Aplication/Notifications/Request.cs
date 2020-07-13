using MediatR;

namespace GyL.DDD.DotNet.Aplication.Notifications
{
    public class Request<TResponse> : BaseNotifiable, IRequest<TResponse> where TResponse : class
    { }
}
