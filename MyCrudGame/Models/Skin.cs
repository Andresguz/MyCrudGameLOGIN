using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyCrudGame.Models
{
    [Table("skins")]
    public partial class Skin
    {
        public Skin()
        {
            PlayerSkins = new HashSet<PlayerSkin>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }

        [InverseProperty(nameof(PlayerSkin.Skin))]
        public virtual ICollection<PlayerSkin> PlayerSkins { get; set; }
    }
}
