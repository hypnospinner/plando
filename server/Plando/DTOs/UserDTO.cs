using Plando.Models.Users;

namespace Plando.DTOs
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Role = user.Identity.Role;
            LaundryId = user.LaundryId;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        public int? LaundryId { get; set; }
    }
}