using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RAS.Bootcamp.Api.Net.Datas.Entities;

namespace RAS.Bootcamp.Api.Net.Datas
{
    public partial class EMarketDbContext : DbContext
    {
        public EMarketDbContext()
        {
        }

        public EMarketDbContext(DbContextOptions<EMarketDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; } = null!;
        public virtual DbSet<Pembely> Pembelies { get; set; } = null!;
        public virtual DbSet<Penjual> Penjuals { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=EMarketDb; User Id=postgres; Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasIndex(e => e.IdPenjual, "IX_Barangs_IdPenjual");

                entity.Property(e => e.Kode).HasMaxLength(10);

                entity.Property(e => e.Nama).HasMaxLength(100);

                entity.HasOne(d => d.IdPenjualNavigation)
                    .WithMany(p => p.Barangs)
                    .HasForeignKey(d => d.IdPenjual);
            });

            modelBuilder.Entity<Pembely>(entity =>
            {
                entity.HasIndex(e => e.IdUser, "IX_Pembelies_IdUser");

                entity.Property(e => e.NoHp).HasMaxLength(15);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Pembelies)
                    .HasForeignKey(d => d.IdUser);
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasIndex(e => e.IdUser, "IX_Penjuals_IdUser");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Penjuals)
                    .HasForeignKey(d => d.IdUser);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
