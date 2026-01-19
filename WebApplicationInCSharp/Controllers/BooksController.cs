using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using WebApplicationInCSharp.Models;
namespace WebApplicationInCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = _context.Book.ToList();

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            var rows = await _context.Book
                .Where(b => b.ID == id)
                .ExecuteUpdateAsync(b => b
                    .SetProperty(bk => bk.Title, book.Title)
                    .SetProperty(bk => bk.Author, book.Author)
                    .SetProperty(bk => bk.YearPublished, book.YearPublished)
                );


            return Ok(book);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var rows = await _context.Book.Where(b => b.ID == id).ExecuteDeleteAsync();

            return Ok();
        }
    }
}
