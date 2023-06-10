using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Models {
    public class BookContext : DbContext {
        public BookContext (DbContextOptions<BookContext> options) : base (options) { }
        public DbSet<Book> books { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }
    }
}