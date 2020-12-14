using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Microsoft.EntityFrameworkCore;
using Plando.Common;
using Plando.Models;
using Plando.Models.Users;

namespace Plando.Commands.Auth
{
    public class RegisterManager : RegisterUser
    {
        public int LaundryId { get; set; } = -1;
    }

    public class RegisterManagerHandler : HandlerWithApplicationContext, ICommandHandler<RegisterManager>
    {
        public RegisterManagerHandler(ApplicationContext context) : base(context) { }

        public async Task HandleAsync(RegisterManager command)
        {
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
            };

            var identity = new Identity
            {
                Email = command.Email,
                Password = command.Password
            };

            if (command.LaundryId != -1)
                if (await _context.Laundries.AnyAsync(x => x.Id == command.LaundryId))
                    user.LaundryId = command.LaundryId;

            var savedUser = _context.Users.Add(user);
            identity.UserId = savedUser.Entity.Id;

            _context.Identities.Add(identity);
            await _context.SaveChangesAsync();
        }
    }
}