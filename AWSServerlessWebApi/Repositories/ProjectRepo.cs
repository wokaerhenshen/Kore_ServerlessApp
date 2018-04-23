using core_backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_backend.Repositories
{
    public class ProjectRepo
    {

        ApplicationDbContext _context;

        public ProjectRepo (ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateProject(int ClientId,string Name, string StartDate, string EndDate)
        {
            Project project = new Project()
            {
                ClientId = ClientId,
                Name = Name,
                StartDate = Convert.ToDateTime(StartDate),
                EndDate = Convert.ToDateTime(EndDate)
            };
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public Project GetOneProject(int id)
        {
            return _context.Projects.Where(i => i.ProjectId == id).FirstOrDefault();
        }

        public void UpdateOneProject(int id, string Name, string StartDate, string EndDate)
        {
            Project project = _context.Projects.Where(i => i.ProjectId == id).FirstOrDefault();
            project.Name = Name;
            project.StartDate = Convert.ToDateTime(StartDate);
            //05/05/2005
            project.EndDate = Convert.ToDateTime(EndDate);
            _context.SaveChanges();
        }

        public void DeleteOneProject(int id)
        {
            Project project = _context.Projects.Where(i => i.ProjectId == id).FirstOrDefault();
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}
