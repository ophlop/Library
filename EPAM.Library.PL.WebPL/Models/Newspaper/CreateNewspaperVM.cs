using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EPAM.Library.PL.WebPL.Models.Newspaper
{
    public class CreateNewspaperVM
    {
        [Required]
        [StringLength(300)]
        [DisplayName("Title")]
        public string Name { get; set; }

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
        [Range(1, int.MaxValue, ErrorMessage = "The field Pages must be greater than 0")]
        public int Pages { get; set; }

        [Required]
        [YearRange(1400, ErrorMessage = "Publication year should be no earlier than 1400 and no later than this year")]
        [DisplayName("Publication year")]
        public int PublicationYear { get; set; }

        [StringLength(9, MinimumLength = 9)]
        [RegularExpression("^[0-9]{4}-[0-9]{4}$", ErrorMessage = "Wrong ISSN format")]
        public string ISSN { get; set; }
        
        [DisplayName("Issue number")]
        public string IssueNumber { get; set; }

        [Required]
        [DisplayName("Issue date")]
        [UIHint("date")]
        public DateTime IssueDate { get; set; }
        public string Description { get; set; }
        
    }
}
