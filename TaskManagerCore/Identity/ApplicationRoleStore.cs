﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerCore.Data;

namespace TaskManagerCore.Identity
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole,ApplicationDbContext>
    {
        public ApplicationRoleStore(ApplicationDbContext _dbContext,IdentityErrorDescriber _identityErrorDescriber) : base(_dbContext, _identityErrorDescriber)
        {

        }
    }
}
