using SoftwareEngineering.IService;
using SoftwareEngineering.Models;

namespace SoftwareEngineering.Service
{
    public class UserService : IUserService
    {
        public User Login(User oUser)
        {
            //var user = null;

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(oUser.Password, User.Password);

            if (!isValidPassword)
            {
                return null;
            }
            return null;
        }

        public User Register(User oUser)
        {
            oUser.Password = BCrypt.Net.BCrypt.HashPassword(oUser.Password);

        }
    }
}
