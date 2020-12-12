using Plando.Models.Laundries;

namespace Plando.DTOs
{
    public class LaundryDTO
    {
        public LaundryDTO(Laundry laundry)
        {
            Id = laundry.Id;
            Address = laundry.Address;
            ManagerId = laundry.ManagerId;
        }

        public int Id { get; set;}
        public string Address { get; set; }
        public int ManagerId { get; set; }
    }
}

