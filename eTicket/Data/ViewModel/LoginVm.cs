using System.ComponentModel.DataAnnotations;

namespace eTicket.Data.ViewModel
{
    public class LoginVm
    {
        [Display(Name ="Email address")]
        [Required(ErrorMessage ="Email Address is Required!")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
