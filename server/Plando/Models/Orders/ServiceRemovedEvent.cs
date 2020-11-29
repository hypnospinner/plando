namespace Plando.Models.Orders
{
    public class ServiceRemovedEvent : EventBase
    {
        public int ServiceId { get; set; }
        public int OrderId { get; set; }
    }
}