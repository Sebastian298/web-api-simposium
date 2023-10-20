using System.ComponentModel.DataAnnotations;

namespace web_api_simposium.Models.Operations
{
    public class UserRegistration
    {
        [Required(ErrorMessage ="The {0} is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The number of characters of the user name must be between 5 to 50")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜ]*$", ErrorMessage = "The {0} does not have a valid format")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "The number of characters of the user last name must be between 4 to 30")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]*$", ErrorMessage = "The {0} does not have a valid format")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(45, MinimumLength = 8, ErrorMessage = "The number of characters of the password must be between 8 to 45")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "The password does not have a valid format, it must have at least one lowercase and uppercase letter, at least one number and one special character.")]
        public string Password { get; set; }

    }

    public class UserValidation
    {
        [Required(ErrorMessage = "The {0} is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The {0} is required")]
        public string Password { get; set; }
    }

    public class UserLoginResponse
    {
        public bool Success { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
