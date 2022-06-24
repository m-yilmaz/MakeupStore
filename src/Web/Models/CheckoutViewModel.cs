using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CheckoutViewModel
    {
        public BasketViewModel Basket { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(180, ErrorMessage = "Max {1} characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(100, ErrorMessage = "Max {1} characters")]
        public string City { get; set; }

        [MaxLength(60, ErrorMessage = "Max {0} characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(180, ErrorMessage = "Max {1} characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(18, ErrorMessage = "Max {1} characters")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Required")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "Required")]
        [CreditCard(ErrorMessage = "Invalid")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^(0[1-9]|1[1-2])\/[0-9]{2}$", ErrorMessage = "Invalid")]
        public string CardExpire { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[0-9]{3,4}$",ErrorMessage = "Invalid")]
        public string CardCvv { get; set; }
    }
}
