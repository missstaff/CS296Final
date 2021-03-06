﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Models
{
    public class Scores
    {
        [Key]
        public int scoresID { get; set; }

        public AppUser Username { get; set; }

        public string Ranking { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }

    }
}
