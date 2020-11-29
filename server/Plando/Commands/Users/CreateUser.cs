using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Plando.Models;

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

    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly ApplicationContext _context;

        public CreateUserHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(CreateUser command)
        {
            var user = new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
                Role = UserRole.Client
            };

            _context.Users.Add(user);
            var id = await _context.SaveChangesAsync();

            command.Id = id;
        }
    }
}