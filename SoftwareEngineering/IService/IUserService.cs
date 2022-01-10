using SoftwareEngineering.Models;
using SoftwareEngineering.Models.DTOs;
using System;
using System.Linq;



namespace SoftwareEngineering.IService
{
    public interface IUserService
    {
        string Register(RegisterUserDTO registerUserDTO);
        string Login(LoginUserDTO loginUserDTO);
    }
}
