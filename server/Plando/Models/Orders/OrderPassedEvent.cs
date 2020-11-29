namespace Plando.Models.Orders
{
    public class OrderPassedEvent : EventBase
    {
        public int OrderId { get; set; }
    }
}