using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Plando.Common;
using Plando.Models;
using Plando.Models.Users;

namespace Plando.Commands.Users
{
    public class CreateUser : ICommand
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateUserHandler : HandlerWithApplicationContext, ICommandHandler<CreateUser>
    {
        public CreateUserHandler(ApplicationContext context) : base(context) { }

        public async Task HandleAsync(CreateUser command)
        {
            var user = new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
            };

            var identity = new Identity()
            {
                Email = command.Email,
                Password = command.Password,
                Role = UserRole.Client
            };

            var entry = _context.Users.Add(user);
            _context.Identities.Add(identity);

            await _context.SaveChangesAsync();

            command.Id = entry.Entity.Id;
        }
    }
}