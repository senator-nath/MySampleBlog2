namespace MySampleBlog2.Model.ModelDto.UserDto
{
    public class AuthenticateUserDto
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
public class AuthenticateUserDtos
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}