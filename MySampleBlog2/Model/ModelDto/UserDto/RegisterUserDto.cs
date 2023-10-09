using System.ComponentModel.DataAnnotations;

namespace MySampleBlog2.Model.ModelDto.UserDto
{
    public class RegisterUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$.!%*#?&^])[A-Za-z\d@$!%*#?&^]{8,}$")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
