using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerCore.Identity;
using TaskManagerCore.ViewModels;

namespace TaskManagerCore.ServiceContracts
{
    public interface IUserService
    {
        Task<ApplicationUser> Authenticate(LoginViewModel loginVModel);
    }
}
