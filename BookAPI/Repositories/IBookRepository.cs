using BookAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task Delete(int id);
        Task Update(Book newBook);
        Task<Book> Create (Book newBook);
    }
}
