using System.ComponentModel.DataAnnotations;

namespace EPAM.Library.PL.WebPL.ViewModels.AuthorVM
{
    public class CreateAuthorViewModel
    {
        [Required]
        [Display(Name = "AuthorName")]
        public string Name { get; set; }
        [Required]
        public string SecondName { get; set; }
    }
}
