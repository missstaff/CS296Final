using System;
using System.ComponentModel.DataAnnotations;

namespace StephenKingFanSite.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 50 characters")]
        [Required]
        public string Title { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "Director name must be between 2 and 60 characters")]
        [Required]
        public string Director { get; set; }

        [Required]
        public DateTime PremiereDate { get; set; }

        public string Genre { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
    }
}
