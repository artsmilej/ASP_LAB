using Microsoft.AspNetCore.Mvc;
using ASP_LAB_7.Models; 
using System.Collections.Generic;
using System.Linq;

namespace ASP_LAB_7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly List<Book> _books = new List<Book>();

        // GET: api/books
        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return Ok(_books);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            _books.Add(book);
            return CreatedAtAction(nameof(GetBooks), new { title = book.Title }, book);
        }

        // DELETE: api/books/{title}
        [HttpDelete("{title}")]
        public ActionResult DeleteBook(string title)
        {
            var book = _books.FirstOrDefault(b => b.Title == title);
            if (book == null)
            {
                return NotFound();
            }

            _books.Remove(book);
            return NoContent();
        }
    }
}