using SoftwareEngineering.IService;
using SoftwareEngineering.Models;
using SoftwareEngineering.Models.DTOs;
using SoftwareEngineering.Data;
using System.Linq;

namespace SoftwareEngineering.Service
{
    public class UserService : IUserService
    {
        EBookApplicationContext context;
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        
        public UserService(IJWTAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            context = new EBookApplicationContext();
        }
        public string Login(RegisterUserDTO registerUserDTO)
        {
            var user = context.Users.Where(x => x.Email == registerUserDTO.Email).FirstOrDefault<User>();
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(registerUserDTO.Password, user.Hash);
            if (isValidPassword)
                return jwtAuthenticationManager.Authenticate("a", "b");
            return null;


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
            user.Email = registerUserDto.Email;
            user.Hash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password);
            context.Add<User>(user);
            context.SaveChanges();
            //jwtAuthenticationManager.Authenticate("a", "b");
            return null;

        }
    }
}
