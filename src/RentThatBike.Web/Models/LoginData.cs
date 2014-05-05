using System.ComponentModel.DataAnnotations;

namespace RentThatBike.Web.Models
{
    public class LoginData
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string Redirect { get; set; }
    }
}