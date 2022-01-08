using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SoftwareEngineering.Models;

#nullable disable

namespace SoftwareEngineering.Data
{
    public partial class EBookApplicationContext : DbContext
    {
        public EBookApplicationContext()
        {
        }

        public EBookApplicationContext(DbContextOptions<EBookApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookProvider> BookProviders { get; set; }
        public virtual DbSet<BookSession> BookSessions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:ebookapp.database.windows.net,1433;Initial Catalog=E-BookApplication;Persist Security Info=False;User ID=Erdem;Password=Harques.1999;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.Email, "IX_Admin")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "IX_Admin_1");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hash).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsFixedLength(true);

                entity.Property(e => e.Salt).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.HasIndex(e => e.Isbn, "IX_Book")
                    .IsUnique();

                entity.HasIndex(e => e.BookLink, "IX_Book_1")
                    .IsUnique();

                entity.Property(e => e.BookLink)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.BookProvider)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.BookProviderId)
                    .HasConstraintName("FK_Book_BookProvider");
            });

            modelBuilder.Entity<BookProvider>(entity =>
            {
                entity.ToTable("BookProvider");

                entity.HasIndex(e => e.Email, "IX_BookProvider")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "IX_BookProvider_1")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hash).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsFixedLength(true);

                entity.Property(e => e.Salt).IsRequired();
            });

            modelBuilder.Entity<BookSession>(entity =>
            {
                entity.ToTable("BookSession");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookSessions)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BookSession_BookSession");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookSessions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_BookSession_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "IX_User")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "IX_User_1")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hash).IsRequired();

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsFixedLength(true);

                entity.Property(e => e.Salt).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
