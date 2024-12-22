using bookstore.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
    }
}