using Convey.CQRS.Commands;
using Plando.Models.Orders;

namespace Plando.Commands.Orders
{
    public class FinishOrder : OrderFinishedEvent, ICommand
    {
        public int ClientId { get; set; }
    }
}