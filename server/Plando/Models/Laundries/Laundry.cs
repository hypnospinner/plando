using System.ComponentModel.DataAnnotations;
using Plando.Models.Users;

namespace Plando.Models.Laundries
{
    public class Laundry
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public int ManagerId { get; set; }
        public User Manager { get; set; }
    }
}