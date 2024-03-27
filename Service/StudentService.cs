using AlRayan.Data;
using AlRayan.Models.MainEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Service
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _user;
        public StudentService(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        public async Task AssignCourse(ChooseCourseViewModel model)
        {

            var student = _context.Students.Where(x => x.UserId == model.UserId).FirstOrDefault();
            if (student is not null)
            {
                Student_Course student_Course = new()
                {

                    CourseId = model.CourseId,
                    StudentId = student.Id,
                };

                _context.Add(student_Course);
                _context.SaveChanges();
            }
        }

        public List<CourseName> GetMyCourses(string userId)
        {
            return _context.Student_Courses
                    .Include(s => s.Student)
                    .Include(c => c.Course)
                    .Where(c => c.Student.UserId == userId)
                    .Select(s => new CourseName { Name = s.Course.Name })
                    .Distinct()
                    .ToList();
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _user.Users
                 .Where(i => i.Type == Models.Type.student)
                 .Select(c => new SelectListItem { Value = c.Id, Text = c.UserName })
                 .OrderBy(c => c.Text)
                 .AsNoTracking()
                 .ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
