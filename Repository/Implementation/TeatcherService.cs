using AlRayan.Data;
using AlRayan.Models.MainEntity;
using AlRayan.Repository.Abstract;
using AlRayan.ViewModel.Teatcher;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Repository.Implementation
{
    public class TeatcherService:ITeatcherService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;
        public TeatcherService(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }


        public IEnumerable<SelectListItem> GetSelectList()
        {
           // _context.Teatchers.Select(c => new SelectListItem { Value = , Text = c.UserName });
            return _user.Users
                .Where(i => i.Type == Models.Type.teatcher)
                .Select(c => new SelectListItem { Value = c.Id, Text = c.UserName })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
        public async Task Create(AssignTeatcherForm model)
        {
            Teatcher teatcher = new()
            {
                UserId = model.UserId,
                IsMarried = model.IsMarried,
                CenterId = model.CenterId,
                CourseId = model.CourseId

            };
            _context.Add(teatcher);
            _context.SaveChanges();
        }

        public Teatcher? GetById(int id)
        {
                // _context.Teatchers
                //.Include(u => u.User)
                //.ThenInclude(c => c.Center)
                //.Include(u => u.Course)
                //.AsNoTracking()
                //.SingleOrDefault(t => t.Id == id);

           return _context.Teatchers
                .Include(u => u.User)
                .Include(c => c.Center)
                .Include(c => c.Course)
                .AsNoTracking()
                .SingleOrDefault(t => t.Id == id);
            
        }

        public async Task<Teatcher?> Update(EditTeatcherForm model)
        {
            var teatcher = _context.Teatchers.Find(model.Id);
            if (teatcher == null)
                return null;
            teatcher.CenterId = model.CenterId;
            teatcher.CourseId = model.CourseId;
            
            _context.SaveChanges();
            return teatcher;
        }
    }
}
