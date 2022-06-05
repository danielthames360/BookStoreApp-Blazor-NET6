using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA49A0F7A5")
                    .IsUnique();

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "70cde050-5520-4970-9317-ebae7c03c733"
                },
                  new IdentityRole
                  {
                      Name = "Administrator",
                      NormalizedName = "ADMINISTRATOR",
                      Id = "cfcc303a-d6b5-4276-aad2-47a7f2cfe2e0"
                  }
                );

            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
          new ApiUser
          {
              Id = "1e9a439e-59c4-485e-a7fb-582aa9dac9d3",
              Email = "admin@bookstore.com",
              NormalizedEmail = "ADMIN@BOOKSTORE.COM",
              UserName = "admin@bookstore.com",
              NormalizedUserName = "ADMIN@BOOKSTORE.COM",
              FirstName = "System",
              LastName = "Admin",
              PasswordHash = hasher.HashPassword(null, "P@ssword1")
          },
            new ApiUser
            {
                Id = "93c70946-9052-4a3f-9368-ec97a29cee7a",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }
          );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "70cde050-5520-4970-9317-ebae7c03c733",
                    UserId = "93c70946-9052-4a3f-9368-ec97a29cee7a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cfcc303a-d6b5-4276-aad2-47a7f2cfe2e0",
                    UserId = "1e9a439e-59c4-485e-a7fb-582aa9dac9d3"
                }
                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
