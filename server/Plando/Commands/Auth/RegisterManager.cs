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
            var user = _context.Users.Add(new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
            });

            _context.Identities.Add(new Identity()
            {
                Email = command.Email,
                Password = command.Password,
                Role = UserRole.Manager
            });

            if (command.LaundryId is -1)
            {
                await _context.SaveChangesAsync();
                return;
            }

            var laundry = await _context.Laundries.FirstOrDefaultAsync(x => x.Id == command.LaundryId);

            if (laundry is null)
            {
                // log that we can't bind manager to non existing laundry
            }

            laundry.ManagerId = user.Entity.Id;

            _context.Laundries.Update(laundry);
            await _context.SaveChangesAsync();
        }
    }
}