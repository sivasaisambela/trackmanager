using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerCore.Identity;
using TaskManagerCore.ServiceContracts;
using TaskManagerCore.ViewModels;

namespace TaskManagerCore.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationUserManager _appUserMgr;
        private readonly ApplicationSignInManager _appSignInMgr;

        public UserService(ApplicationUserManager appUserMgr,ApplicationSignInManager appSignInMgr)
        {
            _appUserMgr = appUserMgr;
            _appSignInMgr = appSignInMgr;
        }
        public async Task<ApplicationUser> Authenticate(LoginViewModel loginVModel)
        {
           var result= await _appSignInMgr.PasswordSignInAsync(loginVModel.Username,loginVModel.Password,false,false);
            if(result.Succeeded)
            {
                var applicationUsr = await _appUserMgr.FindByNameAsync(loginVModel.Username);
                applicationUsr.PasswordHash = null;
                return applicationUsr;
            }
            else
            {
                return null;
            }
        }
    }
}
