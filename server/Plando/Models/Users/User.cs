using System.ComponentModel.DataAnnotations;

namespace Plando.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public string Salt { get; set; }
        public UserRole Role { get; set; }
    }
}