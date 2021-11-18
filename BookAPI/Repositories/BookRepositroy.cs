using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public class BookRepositroy : IBookRepository
    {
        private readonly BookContext _context ;
        public BookRepositroy(BookContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book newBook)
        {
            _context.books.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }

        public async Task Delete(int id)
        {
            var book = await _context.books.FindAsync(id);
            _context.books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Book>> Get()
        {
            return await _context.books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            return await _context.books.FindAsync(id);
        }

        public async Task Update(Book newBook)
        {
            _context.Entry(newBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
