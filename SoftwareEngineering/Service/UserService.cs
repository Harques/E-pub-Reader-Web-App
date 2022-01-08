using SoftwareEngineering.IService;
using SoftwareEngineering.Models;
using SoftwareEngineering.Models.DTOs;

namespace SoftwareEngineering.Service
{
    public class UserService : IUserService
    {
        public User Login(RegisterUserDTO registerUserDto)
        {
            return null; 
            ////var user = null;

            //bool isValidPassword = BCrypt.Net.BCrypt.Verify(oUser.Password, User.Password);

            //if (!isValidPassword)
            //{
            //    return null;
            //}
            //return null;
        }

        public User Register(RegisterUserDTO registerUserDto)
        {

            User user = new User();
            user.Hash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password);

        }
    }
}
