﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication3.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }


        [ForeignKey("Users")]

        public int UserId { get; set; }
        public virtual Users Users { get; set; }

        public int rating { get; set; }
        public DateTime ReviewDate { get; set; }

        [Required]
        [StringLength(5000)] 
        public string ReviewText { get; set; }

        public Reviews()
        {
            
        }
    }
}
