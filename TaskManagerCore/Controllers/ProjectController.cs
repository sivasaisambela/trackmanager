using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerCore.Data;
using TaskManagerCore.Identity;
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
            //Project p= null;
            if (ModelState.IsValid)
            {
                await _dbContext.Projects.AddAsync(project);

                await _dbContext.SaveChangesAsync();
                project = (Project)_dbContext.Projects.OrderByDescending(x => x.ProjectId).Take(1);
                return project;
            }
            else
            {
                return null;
            }
            
           
        }

        [HttpPut]
        [Route("api/projects")]
        public Project Put([FromBody]Project project)
        {
            Project existingProj = _dbContext.Projects.Where(x => x.ProjectId == project.ProjectId).FirstOrDefault();
            if(existingProj!=null)
            {
                existingProj.ProjectName = project.ProjectName;
                existingProj.DateOfStart = project.DateOfStart;
                existingProj.TeamSize = project.TeamSize;
                _dbContext.Projects.Update(existingProj);
                _dbContext.SaveChanges();
                return existingProj;
            }
            else
            {
                return null;
            }
        }

        [HttpDelete]
        [Route("api/projects")]
        public int Delete(int ProjectID)
        {
            Project existingProj = _dbContext.Projects.Where(x => x.ProjectId == ProjectID).FirstOrDefault();
            if (existingProj != null)
            {
               
                _dbContext.Projects.Remove(existingProj);
                _dbContext.SaveChanges();
                return ProjectID;
            }
            else
            {
                return -1;
            }
        }


        [HttpGet]
        [Route("api/projects/search/{searchby}/{searchtext}")]
        public List<Project> Search(string searchBy,string searchText)
        {
            List<Project> projects = null;
            if (searchBy=="ProjectID")
            {
                 projects = (List<Project>)_dbContext.Projects.Where(x => x.ProjectId.ToString().Contains(searchText)).ToList(); ;
            }
            else if(searchBy=="ProjectName")
            {
                projects = (List<Project>)_dbContext.Projects.Where(x => x.ProjectName.Contains(searchText)).ToList();
            }
            if (searchBy == "DateOfStart")
            {
                projects = (List<Project>)_dbContext.Projects.Where(x => x.DateOfStart.ToString().Contains(searchText)).ToList();
            }
            if(searchBy=="TeamSize")
            {
                 projects = (List<Project>)_dbContext.Projects.Where(x => x.TeamSize.ToString().Contains(searchText)).ToList();
            }

            return projects;
        }
    }
}
