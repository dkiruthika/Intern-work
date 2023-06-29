using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserData
    {
        [Required(ErrorMessage = "Username is required must")]
        // [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Username should not contain numbers or special characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required must")]
        public string Password { get; set; }
        public string Roles { get; set; }
    }

}