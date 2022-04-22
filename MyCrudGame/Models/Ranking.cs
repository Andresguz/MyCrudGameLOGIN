using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyCrudGame.Models
{
    public class Ranking
    {
        [Key]
      
        public int Id { get; set; }
     
        public double Time { get; set; }
      

        public int Orbs { get; set; }
        public int Stylish { get; set; }
        public int Damage { get; set; }
        public int ItemUsed { get; set; }
        public int RankBonus { get; set; }
        public int? PlayerId { get; set; }


    }
}
