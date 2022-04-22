using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyCrudGame.Models;

#nullable disable

namespace MyCrudGame.Data
{
    public partial class CRUDMyGameContext : DbContext
    {
       
        public CRUDMyGameContext()
        {
        }

        public CRUDMyGameContext(DbContextOptions<CRUDMyGameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerSkin> PlayerSkins { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Skin> Skins { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; initial catalog=CRUDMyGame; Trusted_Connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NickName).IsFixedLength(true);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Player)
                    .HasForeignKey<Player>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_players_users");
            });

            modelBuilder.Entity<PlayerSkin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerSkins)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerSkin_players");

                entity.HasOne(d => d.Skin)
                    .WithMany(p => p.PlayerSkins)
                    .HasForeignKey(d => d.SkinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerSkin_skins");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Icon).IsFixedLength(true);

                entity.Property(e => e.Name).IsFixedLength(true);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_ranks_players");
            });

            modelBuilder.Entity<Skin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsFixedLength(true);

                entity.Property(e => e.Name).IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Mnk).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<MyCrudGame.Models.Ranking> Ranking { get; set; }
    }
}
