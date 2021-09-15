using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MusicaAPI.Models
{
    public partial class musicaDBContext : DbContext
    {
        public musicaDBContext()
        {
        }

        public musicaDBContext(DbContextOptions<musicaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumType> AlbumTypes { get; set; }
        public virtual DbSet<VwAlbumsGeneral> VwAlbumsGenerals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=musicalog;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.AlbumLabel).HasMaxLength(255);

                entity.Property(e => e.AlbumName).HasMaxLength(255);

                entity.Property(e => e.AlbumTypeId).HasColumnName("AlbumTypeID");

                entity.Property(e => e.ArtistName).HasMaxLength(255);

                entity.HasOne(d => d.AlbumType)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.AlbumTypeId)
                    .HasConstraintName("FK_Albums_AlbumTypes");
            });

            modelBuilder.Entity<AlbumType>(entity =>
            {
                entity.Property(e => e.AlbumTypeId).HasColumnName("AlbumTypeID");

                entity.Property(e => e.AlbumTypeDescr).HasMaxLength(255);
            });

            modelBuilder.Entity<VwAlbumsGeneral>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_AlbumsGeneral");

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.AlbumLabel).HasMaxLength(255);

                entity.Property(e => e.AlbumName).HasMaxLength(255);

                entity.Property(e => e.AlbumTypeDescr).HasMaxLength(255);

                entity.Property(e => e.AlbumTypeId).HasColumnName("AlbumTypeID");

                entity.Property(e => e.ArtistName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
