using System.ComponentModel.DataAnnotations;

namespace projCrud.Models
{
    public class Center
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public required string Location { get; set; }

        public ICollection<Donor> Donors { get; set; } = new List<Donor>();
    }
}
