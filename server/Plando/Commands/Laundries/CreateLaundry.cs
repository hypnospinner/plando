using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Plando.Common;
using Plando.Models;
using Plando.Models.Laundries;


namespace Plando.Commands.Laundries
{
    public class CreateLaundry : ICommand
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int ManagerId { get; set; }
    }

    public class CreateLaundryHandler : HandlerWithApplicationContext, ICommandHandler<CreateLaundry>
    {
        public CreateLaundryHandler(ApplicationContext context) : base(context) { }

        public async Task HandleAsync(CreateLaundry command)
        {
            var laundry = new Laundry()
            {
                Address = command.Address,
                ManagerId = command.ManagerId
            };

            var entry = _context.Laundries.Add(laundry);
            await _context.SaveChangesAsync();

            command.Id = entry.Entity.Id;
        }
    }
}