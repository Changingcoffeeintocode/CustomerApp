using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entieties
{
    [Table("CustomerInfo")]
    public class Customer : BaseEntity
    {
        [Required(ErrorMessage = "Please provide your name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide your surname")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Please provide your mobile number")]
        [Display(Name = "Mobile number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "The number should have nine digits")]
        public string TelephoneNumber { get; set; }

        [Required(ErrorMessage = "Please provide your adress")]
        [Display(Name = "Adress")]
        public string Adress { get; set; }
    }
}