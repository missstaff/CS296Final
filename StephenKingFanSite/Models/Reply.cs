using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Models
{
    public class Reply
    {
        [Key]
        public int ReplyID { get; set; }

        public AppUser Commenter { get; set; }

        [Required]
        public string ReplyText { get; set; }

        public DateTime Date { get; set; }
    }
}
