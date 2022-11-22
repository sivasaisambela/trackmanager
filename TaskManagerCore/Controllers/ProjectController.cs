using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerCore.Data;
using TaskManagerCore.Models;

namespace TaskManagerCore.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/projects")]
        public List<Project> Index()
        {
           var p= _dbContext.Projects.ToList();
            if (p == null)
            {
                return null;
            }
            return p;
        }

        [HttpPost]
        [Route("api/projects")]
        public async Task<Project> Post([FromBody]Project project)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Projects.AddAsync(project);

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return null;
            }

            return project;
        }
    }
}
