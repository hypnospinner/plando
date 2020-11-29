namespace Plando.Models.Orders
{
    public class OrderCreatedEvent : EventBase
    {
        public int ClientId { get; set; }
        public int LaundryId { get; set; }
        public string Title { get; set; }
    }
}