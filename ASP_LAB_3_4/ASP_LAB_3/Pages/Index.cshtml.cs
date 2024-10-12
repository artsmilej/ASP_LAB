using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ASP_LAB_3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataAccessLayer _dataAccess;

        public DataTable Books { get; set; }
        public DataTable Authors { get; set; }
        public DataTable Genres { get; set; }
        public DataTable Customers { get; set; }
        public DataTable Sales { get; set; }

        public IndexModel(IConfiguration configuration)
        {
            _dataAccess = new DataAccessLayer(configuration);
        }

        public void OnGet()
        {
            Books = _dataAccess.GetData("SELECT * FROM BooksView");
            Authors = _dataAccess.GetAuthors();
            Genres = _dataAccess.GetGenres();
            Customers = _dataAccess.GetCustomers();
            Sales = _dataAccess.GetSales();
           
        }
    }
}