using System.ComponentModel.DataAnnotations;

namespace WEB_GestContact.Models
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Mot de passe")]
        public string Password { get; set; }
    }
}
