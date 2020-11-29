using Convey.WebApi.CQRS;

namespace Plando.Router
{
    public static class OrdersRouter
    {
        public static IDispatcherEndpointsBuilder AddOrdersRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints;
    }
}