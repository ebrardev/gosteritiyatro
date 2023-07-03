using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace gosteritiyatro.Models
{
    public partial class gosteriContext : DbContext
    {
        public gosteriContext()
        {
        }

        public gosteriContext(DbContextOptions<gosteriContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategoriler> Kategorilers { get; set; } = null!;
        public virtual DbSet<Sahne> Sahnes { get; set; } = null!;
        public virtual DbSet<Sanatcilar> Sanatcilars { get; set; } = null!;
        public virtual DbSet<Tiyatrolar> Tiyatrolars { get; set; } = null!;
        public virtual DbSet<Yazarlar> Yazarlars { get; set; } = null!;
        public virtual DbSet<Yonetmenler> Yonetmenlers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Data Source=LAPTOP-P9Q5LKQ9\\SQLEXPRESS;initial Catalog=gosteri;trusted_connection=yes ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoriler>(entity =>
            {
                entity.HasKey(e => e.KategoriId)
                    .HasName("PK__Kategori__AFB6FE70FCD284F0");

                entity.Property(e => e.KategoriId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Sahne>(entity =>
            {
                entity.Property(e => e.SahneId).ValueGeneratedNever();

                entity.HasOne(d => d.Tiyatro)
                    .WithMany(p => p.Sahnes)
                    .HasForeignKey(d => d.TiyatroId)
                    .HasConstraintName("FK__Sahne__tiyatro_i__2A4B4B5E");
            });

            modelBuilder.Entity<Sanatcilar>(entity =>
            {
                entity.HasKey(e => e.SanatciId)
                    .HasName("PK__Sanatcil__209669DA88C0444A");

                entity.Property(e => e.SanatciId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Tiyatrolar>(entity =>
            {
                entity.HasKey(e => e.TiyatroId)
                    .HasName("PK__Tiyatrol__8DDF6828832D2CDA");

                entity.Property(e => e.TiyatroId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Yazarlar>(entity =>
            {
                entity.HasKey(e => e.YazarId)
                    .HasName("PK__Yazarlar__9F64F9FBF26989E8");

                entity.Property(e => e.YazarId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Yonetmenler>(entity =>
            {
                entity.HasKey(e => e.YonetmenId)
                    .HasName("PK__Yonetmen__CAEA46E25DB649D8");

                entity.Property(e => e.YonetmenId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
