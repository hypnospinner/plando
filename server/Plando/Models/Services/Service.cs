using System.ComponentModel.DataAnnotations;

namespace Plando.Models.Services
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

    }
}