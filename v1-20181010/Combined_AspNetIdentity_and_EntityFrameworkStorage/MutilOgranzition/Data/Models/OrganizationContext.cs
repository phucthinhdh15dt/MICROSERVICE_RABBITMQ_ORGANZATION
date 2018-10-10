using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MutilOgranzition.Data.Models
{
    public partial class OrganizationContext : DbContext
    {
        public OrganizationContext()
        {
        }

        public OrganizationContext(DbContextOptions<OrganizationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupService> GroupService { get; set; }
        public virtual DbSet<ProfileOgranzition> ProfileOgranzition { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=PHUCTHINH\\SQL;Database=Organization;User Id=sa;Password=1;");
            }
        }

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

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService);

                entity.Property(e => e.IdService).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ServiceName).HasMaxLength(450);
            });
        }
    }
}
