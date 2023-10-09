using MySampleBlog2.Model;

namespace MySampleBlog2.Repository.UserRepository
{
    public interface IUserRepository
    {
        //bool isUniqueUser(string username, string email);
        //UserDto Authenticate(string username, string password, string email);
        //User Register(string firstname, string lastname, string username, string middlename, string password, string email);
        bool isUniqueUser(string username, string Email);
        User Authenticate(string username, string password, string email);
        //User Register(string username, string firstname, string lastname, string middlename, string password, string email);
        void Register(User registerDto);
        public int Save();



    }

    public class RegisterDto

    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}


