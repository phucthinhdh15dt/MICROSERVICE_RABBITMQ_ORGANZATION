using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlusTechPlusSystem.Data.Models
{
    public partial class PlusTechPlusSystemContext : DbContext
    {
        public virtual DbSet<Ogranzition> Ogranzition { get; set; }
        public virtual DbSet<OgranzitionService> OgranzitionService { get; set; }
        public virtual DbSet<ProfileSystem> ProfileSystem { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=PHUCTHINH\SQL;Database=PlusTechPlusSystem;User Id=sa;Password=1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ogranzition>(entity =>
            {
                entity.HasKey(e => e.IdOgranzition);

                entity.Property(e => e.IdOgranzition).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NameOgranzition).HasMaxLength(200);
            });

            modelBuilder.Entity<OgranzitionService>(entity =>
            {
                entity.ToTable("Ogranzition_Service");

                entity.Property(e => e.IdOgranzition)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.IdService)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LicenseAvailable).HasColumnName("license__available");

                entity.HasOne(d => d.IdOgranzitionNavigation)
                    .WithMany(p => p.OgranzitionService)
                    .HasForeignKey(d => d.IdOgranzition)
                    .HasConstraintName("FK__Ogranziti__IdOgr__20C1E124");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.OgranzitionService)
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("FK__Ogranziti__IdSer__21B6055D");
            });

            modelBuilder.Entity<ProfileSystem>(entity =>
            {
                entity.HasKey(e => e.IdProfile);

                entity.Property(e => e.IdProfile).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(450);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.KeyOgranzition).HasMaxLength(450);

                entity.Property(e => e.KeySystem).HasMaxLength(450);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.NameProfile).HasMaxLength(450);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(100);

                entity.HasOne(d => d.KeyOgranzitionNavigation)
                    .WithMany(p => p.ProfileSystem)
                    .HasForeignKey(d => d.KeyOgranzition)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ProfileSy__KeyOg__1273C1CD");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService);

                entity.Property(e => e.IdService).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NameService).HasMaxLength(450);
            });
        }
    }
}
