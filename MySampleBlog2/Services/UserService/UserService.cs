using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySampleBlog2.Model;
using MySampleBlog2.Model.ModelDto.UserDto;
using MySampleBlog2.Repository.UserRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MySampleBlog2.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepo;
        private readonly AppSettings _appSettings;
        public UserService(IUserRepository userRepo, IOptions<AppSettings> appsettings)
        {
            _userRepo = userRepo;
            _appSettings = appsettings.Value;
        }
        public AuthenticateUserDto Authenticate(string username, string password, string email)
        {
            var response = new AuthenticateUserDto();
            try
            {
                var user = _userRepo.Authenticate(username, password, email);
                password = Helper.HashPassword(password);

                if (user == null)
                {
                    response.Message = "User does not exist";
                    return response;
                }
                if (!user.Email.Equals(email))
                {
                    response.Message = "Email or password is incorrect";
                    return response;
                }
                if (!user.Password.Equals(password))
                {
                    response.Message = "Email or password is incorrect";
                    return response;
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                      new Claim(ClaimTypes.Role, user.Role)
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.Token = tokenHandler.WriteToken(token);
                response.Message = "Login successful";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred: " + ex.Message;
                return response;
            }




        }

        public bool isUniqueUser(string username, string Email)
        {
            try
            {
                var user = _userRepo.isUniqueUser(username, Email);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("User name or email already exist", ex);
            }

        }

        public User Register(string username, string firstname, string lastname, string middlename, string password, string email)
        {
            try
            {
                var registrationPayload = new User
                {
                    UserName = username,
                    FirstName = firstname,
                    LastName = lastname,
                    MiddleName = middlename,
                    Password = Helper.HashPassword(password),
                    Email = email,
                    Role = "Admin"
                };
                _userRepo.Register(registrationPayload);
                return registrationPayload;
            }

            catch
            {
                return new User();

            }
        }
    }
}
