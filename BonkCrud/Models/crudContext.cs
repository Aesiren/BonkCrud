using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BonkCrud.Models
{
    public partial class crudContext : DbContext
    {
        public crudContext()
        {
        }

        public crudContext(DbContextOptions<crudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("Server=tcp:bonkcrud.database.windows.net,1433;Initial Catalog=crud;Persist Security Info=False;User ID=aesiren;Password=(Nightblade0713);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ItemName)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
