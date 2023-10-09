using MySampleBlog2.Model;
using MySampleBlog2.Model.ModelDto.UserDto;

namespace MySampleBlog2.Services.UserService
{
    public interface IUserService
    {
        bool isUniqueUser(string username, string Email);
        AuthenticateUserDto Authenticate(string username, string password, string email);
        User Register(string username, string firstname, string lastname, string middlename, string password, string email);
    }
}
