using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyCrudGame.Models
{
    [Table("PlayerSkin")]
    public partial class PlayerSkin
    {
        public int PlayerId { get; set; }
        public int SkinId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("PlayerSkins")]
        public virtual Player Player { get; set; }
        [ForeignKey(nameof(SkinId))]
        [InverseProperty("PlayerSkins")]
        public virtual Skin Skin { get; set; }
    }
}
