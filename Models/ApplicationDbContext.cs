using Microsoft.EntityFrameworkCore;

namespace BookManagmentSystem.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre>Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(b => b.Books);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(b => b.Books);


        }

    }
}
