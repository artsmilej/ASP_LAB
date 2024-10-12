using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ASP_LAB_4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly XmlDataAccessLayer _xmlDataAccess;

        public List<Book> Books { get; set; }

        public IndexModel()
        {
            _xmlDataAccess = new XmlDataAccessLayer("data.xml");
        }

        public void OnGet()
        {
            Books = _xmlDataAccess.GetBooks();
        }

        public IActionResult OnPostAddBook(string title, string author, string genre, decimal price, DateTime writingDate)
        {
            var newBook = new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                Price = price,
                WritingDate = writingDate
            };

            _xmlDataAccess.AddBook(newBook);
            return RedirectToPage();
        }

        public IActionResult OnPostRemoveBook(string title)
        {
            _xmlDataAccess.RemoveBook(title);
            return RedirectToPage();
        }
    }
}