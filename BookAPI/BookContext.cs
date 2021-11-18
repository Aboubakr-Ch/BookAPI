using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public DbSet<Book> books { get; set; }
    }
}
