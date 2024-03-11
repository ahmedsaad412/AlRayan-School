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
            var selectedTeatcher = model.SelectedTeatchers;
            List<Teatcher> teatchers = new List<Teatcher>();
            //foreach (var item in selectedTeatcher)
            //{
            //    Teatcher teatcher = _context.Teatchers.Where(i=>i.UserId==item).FirstOrDefault(); 
            //    teatchers.Add(teatcher);
            //}

            teatchers =_context.Teatchers.Where(x=>selectedTeatcher.Contains(x.UserId)).ToList();

            Course course = new()
            {
                Name = model.Name,
                Hours = model.Hours,
                Description = model.Description,
                CenterId = model.CenterId,
            };
            _context.Add(course);
            _context.SaveChanges();
            course.Teatchers = teatchers;
            _context.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Courses
                  .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                  .OrderBy(c => c.Text)
                  .AsNoTracking()
                  .ToList();
        }
    }
}
