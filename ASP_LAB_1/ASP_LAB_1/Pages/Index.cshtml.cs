using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ASP_LAB_1.Pages
{
    public class IndexModel : PageModel
    {
       
        [BindProperty]
        [Required(ErrorMessage = "����� �� ���� ���� �������")]
        public string InputText { get; set; }

        [BindProperty]
        [Range(1, 100, ErrorMessage = "����� ������� ���� �� 1 � 100")]
        public int InputNumber { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "���� � ����'�������")]
        public DateTime InputDate { get; set; }

        [BindProperty]
        [EmailAddress(ErrorMessage = "������������ ������ Email")]
        public string InputEmail { get; set; }

        [BindProperty]
        [Url(ErrorMessage = "������������ ������ URL")]
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
