using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly ILogger<BooksController> _logger;
        public BooksController(IBookRepository bookRepository, ILogger<BooksController> logger)
        {
            repository = bookRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            _logger.LogInformation("calliing Get method...");
            return await repository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await repository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            _logger.LogInformation("calliing Post Book method...");
            
            var newBook = await repository.Create(book);
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id },newBook) ;
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            await repository.Update(book);
            return NoContent();    
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var book = await repository.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            await repository.Delete(id);
            return NoContent();
        }
    }
}
