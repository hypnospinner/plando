using Convey.WebApi.CQRS;

namespace Plando.Router
{
    public static class ServicesRouter
    {
        public static IDispatcherEndpointsBuilder AddServicesRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints;
    }
}