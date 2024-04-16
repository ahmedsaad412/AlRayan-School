using AlRayan.Data;
using AlRayan.Models.MainEntity;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Service
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly IWebHostEnvironment _webHost;
        private readonly string _imagePath;

        public CourseService(ApplicationDbContext context, UserManager<ApplicationUser> user ,
            IWebHostEnvironment webHost)
        {
            _context = context;
            _user = user;
            _webHost = webHost;
            _imagePath = $"{_webHost.WebRootPath}{FileSettings.FilePath}";
        }

        public Course? GetById(int id)
        {
            return _context.Courses
                .Where(i => i.IsDeleted == false)
                .Include(c => c.Center)
                .Include(t => t.Teatchers)
                .SingleOrDefault(c => c.Id == id);


        }
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses
                    .Include(c => c.Center)
                    .AsNoTracking()
                    .ToList();
        }

        public IEnumerable<Teatcher> GetAllTeatchersInCourse(int id)
        {
           return _context.Teatchers.Where(a => a.CourseId == id).ToList();
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Courses
                  .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                  .OrderBy(c => c.Text)
                  .AsNoTracking()
                  .ToList();
        }
        public async Task Create(AssignCourseFormViewModel model)
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

            var photoName = await SavePhoto(model.Photo);

            Course course = new()
            {
                Name = model.Name,
                Hours = model.Hours,
                Description = model.Description,
                Photo=photoName,
                CenterId = model.CenterId,
            };
            _context.Add(course);
            _context.SaveChanges();
            #region save at teatcher table
            //course.Teatchers = teatchers;
            //_context.SaveChanges(); 
            #endregion
        }
        public async Task CreateList(List<AssignCourseFormViewModel> model)
        {
            List<Course> listOfCourses = new List<Course>();
            foreach (var c in model)
            {
                var photoName = await SavePhoto(c.Photo);
                Course course = new()
                {
                    Name = c.Name,
                    Hours = c.Hours,
                    Description = c.Description,
                    Photo = photoName,
                    CenterId = c.CenterId,
                };
                listOfCourses.Add(course);
            }
            _context.AddRange(listOfCourses);
            _context.SaveChanges();
        }
        public int RemoveTeatchersInCourse(IEnumerable<Teatcher> relatedTeatcher)
        {
            _context.Teatchers.RemoveRange(relatedTeatcher);
            return _context.SaveChanges();
        }
        public async Task<Course?> Update(EditCourseFormViewModel model)
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
        public void Save()
        {
            _context.SaveChanges();
        }


        private async Task<string> SavePhoto(IFormFile photo)
        {
            var photoName = $"{Guid.NewGuid()}{Path.GetExtension(photo.FileName)}";
            var path = Path.Combine(_imagePath, photoName);
            using var stream = System.IO.File.Create(path);
            await photo.CopyToAsync(stream);
            return photoName;
        }
    }
}
