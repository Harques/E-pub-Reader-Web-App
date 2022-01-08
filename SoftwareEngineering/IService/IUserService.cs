using SoftwareEngineering.Models;
using System;
using System.Linq;



namespace SoftwareEngineering.IService
{
    public interface IUserService
    {
        User Register(User oUser);
        User Login(User oUser);
    }
}
