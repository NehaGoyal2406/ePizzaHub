using System.ComponentModel.DataAnnotations;

namespace ePizzaHub.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }
}
