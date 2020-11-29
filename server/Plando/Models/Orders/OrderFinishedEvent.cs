namespace Plando.Models.Orders
{
    public class OrderFinishedEvent : EventBase
    {
        public int OrderId { get; set; }
    }
}