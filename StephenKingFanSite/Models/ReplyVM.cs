﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Models
{
    public class ReplyVM
    {
        public int PostID { get; set; }
        public string Topic { get; set; }
        public string ReplyText { get; set; }
    }
}
