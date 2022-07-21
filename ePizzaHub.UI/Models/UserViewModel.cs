using System.ComponentModel.DataAnnotations;

namespace ePizzaHub.UI.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="Please enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [Compare("Password" ,ErrorMessage = "Please enter Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
