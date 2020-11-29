using System.ComponentModel.DataAnnotations;

namespace Plando.Models.Laundries
{
    public class Laundry
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public int ManagerId { get; set; }
    }
}