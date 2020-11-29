using System.ComponentModel.DataAnnotations.Schema;

namespace Plando.Models.Orders
{
    public class ServiceCompletedEvent : EventBase
    {
        public int ServiceId { get; set; }
    }
}