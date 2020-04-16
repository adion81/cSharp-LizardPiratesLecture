using System.ComponentModel.DataAnnotations;
using System;

namespace LizardPirates.Models
{
    public class LizardPirate
    {
        [Key]
        public int LizardPirateId {  get; set;}

        [Required]
        public string Name { get; set; }

        [Required]
        public string LizardType { get; set; }

        [Required]
        public string PirateRoll { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}