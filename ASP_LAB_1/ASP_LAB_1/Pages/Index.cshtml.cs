using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ASP_LAB_1.Pages
{
    public class IndexModel : PageModel
    {
       
        [BindProperty]
        [Required(ErrorMessage = "Текст не може бути порожнім")]
        public string InputText { get; set; }

        [BindProperty]
        [Range(1, 100, ErrorMessage = "Число повинно бути між 1 і 100")]
        public int InputNumber { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата є обов'язковою")]
        public DateTime InputDate { get; set; }

        [BindProperty]
        [EmailAddress(ErrorMessage = "Неправильний формат Email")]
        public string InputEmail { get; set; }

        [BindProperty]
        [Url(ErrorMessage = "Неправильний формат URL")]
        public string InputUrl { get; set; }

        public bool IsSubmitted { get; set; } = false;

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            IsSubmitted = true;
        }

    }
}
