using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyCrudGame.Models
{
    [Table("players")]
    public partial class Player
    {
        public Player()
        {
            PlayerSkins = new HashSet<PlayerSkin>();
            Ranks = new HashSet<Rank>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(10)]
        public string NickName { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(User.Player))]
        public virtual User IdNavigation { get; set; }
        [InverseProperty(nameof(PlayerSkin.Player))]
        public virtual ICollection<PlayerSkin> PlayerSkins { get; set; }
        [InverseProperty(nameof(Rank.Player))]
        public virtual ICollection<Rank> Ranks { get; set; }
    }
}
