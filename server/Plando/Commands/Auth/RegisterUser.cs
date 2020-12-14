using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Plando.Common;
using Plando.Models;
using Plando.Models.Users;

namespace Plando.Commands.Auth
{
    public class RegisterUser : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserHandler : HandlerWithApplicationContext, ICommandHandler<RegisterUser>
    {
        public RegisterUserHandler(ApplicationContext context) : base(context) { }

        public async Task HandleAsync(RegisterUser command)
        {
            var savedUser = _context.Users.Add(new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
            });

            _context.Identities.Add(new Identity()
            {
                UserId = savedUser.Entity.Id,
                Email = command.Email,
                Password = command.Password,
                Role = UserRole.Client
            });

            await _context.SaveChangesAsync();
        }
    }
}