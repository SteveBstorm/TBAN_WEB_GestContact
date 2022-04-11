using System.ComponentModel.DataAnnotations;

namespace WEB_GestContact.Models
{
    public class ContactForm
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
    }
}
