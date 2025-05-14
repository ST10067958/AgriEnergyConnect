using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgriEnergyConnect.Models
{
    [Table("User")]
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // "Farmer" or "Employee"

        // Optional: link to a Farmer profile (if the user is a Farmer)
        public int? FarmerId { get; set; }
        public Farmer? Farmer { get; set; }
    }
}
