using MySampleBlog2.Data;
using MySampleBlog2.Model;

namespace MySampleBlog2.Repository.UserRepository
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly ApplicationDbContext _db;
//        private readonly AppSettings _appSettings;

//        public UserRepository(ApplicationDbContext db, IOptions<AppSettings> appsettings)
//        {
//            _db = db;
//            _appSettings = appsettings.Value;
//        }
//        public UserDto Authenticate(string username, string password, string email)
//        {


//            var response = new UserDto();
//            var user = _db.Users.SingleOrDefault(x => x.Email == email);
//            password = Helper.HashPassword(password);


//            if (user == null)
//            {
//                response.Message = "User does not exist";
//                return response;
//            }
//            if (!user.Email.Equals(email))
//            {
//                response.Message = "Email or password is incorrect";
//                return response;
//            }
//            if (!user.Password.Equals(password))
//            {
//                response.Message = "Email or password is incorrect";
//                return response;
//            }
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_appSettings.secret);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new Claim[] {
//                    new Claim(ClaimTypes.Name, user.Id.ToString()),
//                    new Claim(ClaimTypes.Role, user.Role)
//                }),
//                Expires = DateTime.UtcNow.AddDays(7),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            response.Token = tokenHandler.WriteToken(token);
//            response.Message = "Login successful";

//            return response;
//        }

//        public bool isUniqueUser(string username, string email)
//        {
//            var user = _db.Users.SingleOrDefault(x => x.UserName == username && x.Email == email);
//            if (user == null) { return true; }
//            return false;
//        }

//        public User Register(string firstname, string lastname, string username, string middlename, string password, string email)
//        {
//            var userobj = new User()
//            {
//                FirstName = firstname,
//                LastName = lastname,
//                MiddleName = middlename,
//                UserName = username,
//                Email = email,
//                Password = Helper.HashPassword(password),
//                Role = "Admin"
//            };
//            _db.Users.Add(userobj);
//            _db.SaveChanges();
//            userobj.Password = "";
//            return userobj;

//        }
//    }
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _Db;


        public UserRepository(ApplicationDbContext Db)
        {
            _Db = Db;

        }

        public int Save()
        {
            try
            {
                return _Db.SaveChanges() >= 0 ? 1 : 2;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save user", ex);
            }

        }
        public User Authenticate(string username, string password, string email)
        {
            try
            {
                User value = _Db.Users.SingleOrDefault(x => x.UserName == username && x.Email == email && x.Password == password);
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Authenticate user", ex);
            }


        }

        public bool isUniqueUser(string username, string Email)
        {
            try
            {
                var user = _Db.Users.SingleOrDefault(x => x.UserName == username && x.Email == Email);
                if (user == null) { return true; }
                return false;
            }
            catch { return false; }

        }

        public void Register(User registerDto)
        {
            try
            {
                _Db.Users.Add(registerDto);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to register user", ex);
            }
        }

    }
}
