using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Authentication_API.Models
{
    public partial class COMP2001_DThomasContext : DbContext
    {
        public COMP2001_DThomasContext()
        {
        }

        public COMP2001_DThomasContext(DbContextOptions<COMP2001_DThomasContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_DThomas;User Id=DThomas; Password=VwvL746+");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

           

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName }, "UQ__Users__2457AEF09ADDD46A")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534044DB9F7")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CurrentPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
