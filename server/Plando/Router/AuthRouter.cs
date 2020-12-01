using Convey.WebApi;
using Convey.WebApi.CQRS;
using Plando.Commands.Auth;

namespace Plando.Router
{
    public static class AuthRouter
    {
        public static IDispatcherEndpointsBuilder AddAuthRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints
                .Post<AuthenticateUser>(
                    path: "login",
                    afterDispatch: (command, context) =>
                        command.Token is null ? 
                        context.Response.Forbidden() : 
                        context.Response.Ok(command.Token));
    }
}