using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace projCrud.Models
{
    public class Donor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string BloodGroup { get; set; }

        [Required]
        public DateTime DonationDate { get; set; }

        [Required]
        public int CenterId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public Center Center { get; set; }
    }
}