using System.Threading.Tasks;
using Convey.Auth;
using Convey.CQRS.Commands;
using Plando.Models;

namespace Plando.Commands
{
    public class AuthenticateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; } = "";
    }

    public class AuthenticateUserHandler : ICommandHandler<AuthenticateUser>
    {
        private readonly IJwtHandler _jwtHandler;
        private const string _email = "username";
        private const string _password = "password";
        public AuthenticateUserHandler(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        public Task HandleAsync(AuthenticateUser command)
        {
            if ((command.Email, command.Password) is (_email, _password))
            {
                var token = _jwtHandler.CreateToken(
                    command.Email,
                    UserRole.Client.ToString()
                );

                command.Token = token.AccessToken;
            }
            return Task.CompletedTask;
        }
    }
}