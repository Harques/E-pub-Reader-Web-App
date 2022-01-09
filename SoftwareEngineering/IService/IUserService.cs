using SoftwareEngineering.Models;
using SoftwareEngineering.Models.DTOs;
using System;
using System.Linq;



namespace SoftwareEngineering.IService
{
    public interface IUserService
    {
        User Register(RegisterUserDTO registerUserDTO);
        string Login(RegisterUserDTO registerUserDTO);
    }
}
