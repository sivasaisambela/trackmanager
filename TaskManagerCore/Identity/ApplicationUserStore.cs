using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerCore.Data;

namespace TaskManagerCore.Identity
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext _dbContext):base(_dbContext)
        {

        }
    }
}
