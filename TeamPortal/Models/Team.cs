﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeamPortal.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }
    }
}