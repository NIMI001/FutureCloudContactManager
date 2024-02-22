using System.ComponentModel.DataAnnotations;

namespace FutureCloudContactManager.Models.ViewModel
{

    public class RegisterVM
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage ="NIN is required")]
        public string NIN { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
