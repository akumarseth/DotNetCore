using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.DataModel
{
    public partial class API_DBFirstDBContext : DbContext
    {
        public API_DBFirstDBContext()
        {
        }

        public API_DBFirstDBContext(DbContextOptions<API_DBFirstDBContext> options)
            : base(options)
        {
            //Database.SetCommandTimeout(20000);
        }

        public virtual DbSet<Employees> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=API_DBFirstDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
