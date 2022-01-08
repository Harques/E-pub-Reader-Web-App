using SoftwareEngineering.Models;
using SoftwareEngineering.Models.DTOs;
using System;
using System.Linq;



namespace SoftwareEngineering.IService
{
    public interface IUserService
    {
        User Register(RegisterUserDTO user);
        User Login(RegisterUserDTO user);
    }
}
