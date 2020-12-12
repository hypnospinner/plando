using System.Collections.Generic;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Plando.Commands.Users;
using Plando.DTOs;
using Plando.Queries.Users;

namespace Plando.Router
{
    internal static class UsersRouter
    {
        public static IDispatcherEndpointsBuilder AddUserRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints
                // create one user
                .Post<CreateUser>(
                    path: "users",
                    afterDispatch: async (command, context) =>
                    {
                        await context.Response.Created($"users/{command.Id}");
                    },
                    auth: true,
                    roles: "Administrator")
                // delete one user by id
                .Delete<DeleteUser>("users/{Id}",
                afterDispatch: async (command, context) =>
                {
                    context.Response.StatusCode = 204;
                    await context.Response.WriteJsonAsync(new
                    {
                        id = command.Id
                    });
                })
                // get all users (with pagination)
                .Get<GetAllUsers, IEnumerable<UserDTO>>("users")
                // get user by id
                .Get<GetUserById, UserDTO>("users/{Id}");
    }
}