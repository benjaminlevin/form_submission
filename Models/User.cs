using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public class User
    {
        [Required(ErrorMessage="first name is required")]
        [MinLength(4, ErrorMessage="first name must be at least four characters long")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage="last name is required")]
        [MinLength(4, ErrorMessage="last name must be at least four characters long")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage="age is required")]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage="age must be a positive number")] //this limits to three characters, prevents errors regarding nullable values
        [Range(0, int.MaxValue, ErrorMessage="age must be a positive number")] //if Age is int?
        public string Age { get; set; }
        
        [Required(ErrorMessage="e-mail address is required")]
        [EmailAddress(ErrorMessage="e-mail address must be valid")]
        public string Email { get; set; }
        
        [Required(ErrorMessage="password is required")]
        [MinLength(8, ErrorMessage="password must be at least eight characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}