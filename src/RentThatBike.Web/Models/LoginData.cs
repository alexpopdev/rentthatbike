using System.ComponentModel.DataAnnotations;

namespace RentThatBike.Web.Models
{
    public class LoginData
    {
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }


        [Required(ErrorMessage = "Redirect url is required")]
        public string Redirect { get; set; }
    }
}