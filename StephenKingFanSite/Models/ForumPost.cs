using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StephenKingFanSite.Models
{
    public class ForumPost
    {
        public List<Reply> replies = new List<Reply>();

        [Key]
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "Post topic must be between 2 and 60 characters")]
        [Required]
        public string Topic { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Post must between 5 and 1000 characters long.")]
        public string Comments { get; set; }

        public AppUser Name { get; set; }
       
        [Required]
        public DateTime Date { get; set; }

        public List<Reply> Replies
        {
            get
            {
                return replies;
            }
        }

    }
}
