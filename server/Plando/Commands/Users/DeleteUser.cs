using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Plando.Models;

namespace Plando.Commands.Users
{
    public class DeleteUser : ICommand
    {
        public int Id { get; set; }
    }

    public class DeleteUserHandler : ICommandHandler<DeleteUser>
    {
        private readonly ApplicationContext _context;

        public DeleteUserHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(DeleteUser command)
        {
            var user = await _context.Users.FindAsync(command.Id);

            // we can't delete administrator using API
            if (user.Role is UserRole.Administrator)
                throw new Exception("Cannot delete administrator");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}