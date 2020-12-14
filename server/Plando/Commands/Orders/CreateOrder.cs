using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Plando.Models;
using Plando.Common;
using Plando.Models.Orders;

namespace Plando.Commands.Orders
{
    public class CreateOrder : OrderCreatedEvent, ICommand { }

    public class CreateOrderHandler : HandlerWithApplicationContext, ICommandHandler<CreateOrder>
    {
        public CreateOrderHandler(ApplicationContext context) : base(context) { }
        public async Task HandleAsync(CreateOrder command)
        {
            _context.OrderCreatedEvents.Add(command as OrderCreatedEvent);
            await _context.SaveChangesAsync();
        }
    }
}