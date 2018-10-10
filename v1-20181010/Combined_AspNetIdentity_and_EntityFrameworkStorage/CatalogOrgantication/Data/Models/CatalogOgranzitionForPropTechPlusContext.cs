using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatalogOrgantication.Data.Models
{
    public partial class CatalogOgranzitionForPropTechPlusContext : DbContext
    {
        public CatalogOgranzitionForPropTechPlusContext()
        {
        }

        public CatalogOgranzitionForPropTechPlusContext(DbContextOptions<CatalogOgranzitionForPropTechPlusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatalogOgranzition> CatalogOgranzition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=PHUCTHINH\\SQL;Database=CatalogOgranzitionForPropTechPlus;User Id=sa;Password=1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogOgranzition>(entity =>
            {
                entity.HasKey(e => e.IdOgranzition);

                entity.Property(e => e.IdOgranzition).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NameOgranzition).HasMaxLength(450);
            });
        }
    }
}
