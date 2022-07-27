using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EPAM.Library.PL.WebPL.ViewModels.Book
{
    public class CreateBookVM
    {
        [Required]
        [StringLength(300)]
        [DisplayName("Title")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The field Pages must be greater than 0")]
        public int Pages { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(200)]
        [RegularExpression("(^[A-Z][a-z]*(|(-[A-Z]| [A-Z])|( [a-z]+|-[a-z]+)( |-)[A-Z])([a-z]*)*)$" +
            "|(^[А-ЯЁ][а-яё]*(|(-[А-ЯЁ]| [А-ЯЁ])|( [а-яё]+|-[а-яё]+)( |-)[А-ЯЁ])([а-яё]*)*)$"
            , ErrorMessage = "Wrong city format")]
        public string City { get; set; }

        [Required]
        [StringLength(300)]
        public string Publisher { get; set; }

        [Required]
        [YearRange(1400, ErrorMessage = "Publication year should be no earlier than 1400 and no later than this year")]
        [DisplayName("Publication year")]
        public int PublicationYear { get; set; }

        [StringLength(13, MinimumLength = 13)]
        [RegularExpression("^([0-7]|8[0-9]|9[0-4]|9([5-8][0-9]|9[0-3])|99[4-8][0-9]|999[0-9][0-9])-([0-9]{1,7})-([0-9]{1,7})-([0-9]|X)$"
            , ErrorMessage = "Wrong ISBN format")]
        public string ISBN { get; set; }

        [Required, MinLength(1, ErrorMessage = "A book should have at least one author")]
        public List<string> Authors { get; set; }
    }
}
