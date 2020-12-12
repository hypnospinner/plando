using System.ComponentModel.DataAnnotations;

namespace Plando.Models.Users
{
    public class Identity
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}