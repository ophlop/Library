using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EPAM.Library.PL.WebPL.ViewModels.AuthorVM
{
    public class CreateAuthorViewModel
    {
        [Required]
        [RegularExpression("(^[A - Z][a - z] * (| -[A - Z][a - z] *)$)|(^[А-ЯЁ][а-яё]* (|-[А-ЯЁ][а-яё]*)$)")]
        [DisplayName("Author name")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("((^[A-Z]([a-z]*('[A-Z])?)*(|-[A-Z]|( [a-z]+|-[a-z]+)( |-)[A-Z])([a-z]*('[A-Z])?)*)$)" +
                    "|((^[А-ЯЁ]([а-яё]*('[А-ЯЁ])?)*(|-[А-ЯЁ]|( [а-яё]+|-[а-яё]+)( |-)[А-ЯЁ])([а-яё]*('[А-ЯЁ])?)*)$)")]
        [DisplayName("Author name")]
        public string SecondName { get; set; }

        public string ControllerName { get; set; }
    }
}
