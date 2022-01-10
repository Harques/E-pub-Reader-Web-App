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
        public string Login(LoginUserDTO loginUserDTO)
        {
            var user = context.Users.Where(x => x.Email == loginUserDTO.Email).FirstOrDefault<User>();
            if (user == null)
                return null;
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, user.Hash);
            if (isValidPassword)
                return jwtAuthenticationManager.Authenticate();
            return null;
        }

        public string Register(RegisterUserDTO registerUserDto)
        {
            User user = new User();
            var testUser = context.Users.Where(x => x.Email == registerUserDto.Email).FirstOrDefault<User>();
            if(testUser != null)
                return null;
            var testUser2 = context.Users.Where(x => x.Phone == registerUserDto.Phone).FirstOrDefault<User>();
            if (testUser2 != null)
                return null;
            user.Email = registerUserDto.Email;
            user.Hash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password);
            user.Phone = registerUserDto.Phone;
            user.BirthDate = registerUserDto.BirthDate;
            context.Add<User>(user);
            context.SaveChanges();
            return jwtAuthenticationManager.Authenticate();

        }
    }
}
