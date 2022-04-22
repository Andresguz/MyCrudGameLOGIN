using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyCrudGame.Models
{
    [Table("ranks")]
    public partial class Rank
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(40)]
        public string Name { get; set; }
        [Column("icon")]
        [StringLength(10)]
        public string Icon { get; set; }
        public double? MaxExperience { get; set; }
        public double? MinExperience { get; set; }
        public int? PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("Ranks")]
        public virtual Player Player { get; set; }
    }
}
