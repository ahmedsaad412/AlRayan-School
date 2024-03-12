using AlRayan.Data;
using AlRayan.Models.MainEntity;
using AlRayan.Repository.Abstract;
using AlRayan.ViewModel.Course;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Repository.Implementation
{
    public class CourseService:ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public CourseService(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        public async Task Create(AssignCourseForm model)
        {
            #region get list of teatchers by id with ef
            //var selectedTeatcher = model.SelectedTeatchers;
            //List<Teatcher> teatchers = new List<Teatcher>(); 
            //teatchers =_context.Teatchers.Where(x=>selectedTeatcher.Contains(x.UserId)).ToList();
            #endregion
            #region get list of teatchers by id 
            //foreach (var item in selectedTeatcher)
            //{
            //    Teatcher teatcher = _context.Teatchers.Where(i=>i.UserId==item).FirstOrDefault(); 
            //    teatchers.Add(teatcher);
            //} 
            #endregion


            Course course = new()
            {
                Name = model.Name,
                Hours = model.Hours,
                Description = model.Description,
                CenterId = model.CenterId,
            };
            _context.Add(course);
            _context.SaveChanges();
            #region save at teatcher table
            //course.Teatchers = teatchers;
            //_context.SaveChanges(); 
            #endregion
        }

        public Course? GetById(int id)
        {
            return _context.Courses
                .Where(i=>i.IsDeleted==false)
                .Include(c => c.Center)
                .Include(t => t.Teatchers)
                .SingleOrDefault(c => c.Id == id);


        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Courses
                  .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                  .OrderBy(c => c.Text)
                  .AsNoTracking()
                  .ToList();
        }

        public async Task<Course?> Update(EditCourseForm model)
        {
            var course = _context.Courses.Find(model.Id);
            if (course == null)
                return null; 
            course.Name = model.Name;
            course.Hours = model.Hours;
            course.Description = model.Description;
            course.CenterId = model.CenterId;

            _context.SaveChanges();
            return course;
        }
    }
}
