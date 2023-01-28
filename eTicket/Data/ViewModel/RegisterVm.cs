using System.ComponentModel.DataAnnotations;

namespace eTicket.Data.ViewModel
{
    public class RegisterVm
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Fullname is Required!")]
        public string FullName { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email Address is Required!")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords do not match!")]
        public string ConfirmPassword { get; set; } 
    }
}
