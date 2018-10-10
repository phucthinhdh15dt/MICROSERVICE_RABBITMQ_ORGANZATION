using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlusTechPlusSystem.Data.ModelOgranzition
{
    public partial class OrganizationContext : DbContext
    {
        public OrganizationContext()
        {
        }

        public OrganizationContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupService> GroupService { get; set; }
        public DbSet<ProfileOgranzition> ProfileOgranzition { get; set; }
        public DbSet<ServiceOgranzition> ServiceOgranzition { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.IdGroup);

                entity.Property(e => e.IdGroup).ValueGeneratedNever();

                entity.Property(e => e.GroupChildren).HasMaxLength(450);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<GroupService>(entity =>
            {
                entity.HasKey(e => new { e.IdGroup, e.IdService });

                entity.ToTable("Group_Service");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProfileOgranzition>(entity =>
            {
                entity.HasKey(e => e.IdProfile);

                entity.Property(e => e.IdProfile).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServiceOgranzition>(entity =>
            {
                entity.HasKey(e => e.IdService);

                entity.Property(e => e.IdService).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ServiceName).HasMaxLength(450);
            });
        }
    }
}
