using System;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }

        public DateTime ProductionDate { get; set; }

        // Foreign key
        public int FarmerId { get; set; }

        // Navigation property
        public Farmer Farmer { get; set; }
    }
}
