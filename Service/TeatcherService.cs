using AlRayan.Data;
using AlRayan.Models.MainEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Service
{
    public class TeatcherService : ITeatcherService 
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
            
            return _user.Users
                .Where(i => i.Type == Models.Type.teatcher)
                .Select(c => new SelectListItem { Value = c.Id, Text = c.UserName })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
        public IEnumerable<SelectListItem> GetSelectListDistinct()
        {
            //var query = from a in _context.Users.Where(a => a.Type == Models.Type.teatcher)
            //            where !_context.Teatchers.Any(b => b.UserId == a.Id)
            //            select a;
            //var x = from a in _context.Users
            //        join b in _context.Teatchers on a.Id equals b.UserId into joined
            //        from b in joined.DefaultIfEmpty()
            //        where b == null
            //        select a;
            //var result = _context.Users
            //          .Where(a => a.Type == Models.Type.teatcher)
            //          .Where(a => !_context.Teatchers.Any(b => b.UserId == a.Id))
            //          .Select(a => a);
            var teatcherList = _context.Users
                              .Where(a => a.Type == Models.Type.teatcher)
                              .Where(a => !_context.Teatchers.Any(b => b.UserId == a.Id))
                              .ToList();
            var selectlist = teatcherList
                                   .Select(user => new SelectListItem
                                   {
                                       Value = user.Id,
                                       Text = user.UserName
                                   });
            return selectlist;
        }

        public async Task Create(AssignTeatcherFormViewModel model)
        {
            Teatcher teatcher = new()
            {
                UserId = model.Id,
                IsMarried = model.IsMarried,
                CenterId = 1,
                CourseId = model.CourseId

            };
            _context.Add(teatcher);
            _context.SaveChanges();
        }

        public Teatcher? GetById(int id)
        {
            return _context.Teatchers
           .Include(u => u.User)
           .Include(c => c.Center)
           .Include(c => c.Course)
           .SingleOrDefault(t => t.Id == id);
        }
        public async Task<Teatcher?> Update(EditTeatcherFormViewModel model)
        {
            var teatcher = _context.Teatchers.Find(model.Id);
            if (teatcher == null)
                return null;
            teatcher.CenterId = model.CenterId;
            teatcher.CourseId = model.CourseId;
            _context.SaveChanges();
            return teatcher;
        }
        public IEnumerable<Teatcher>? GetAllTeatchers()
        {
            return _context.Teatchers
                .Include(a => a.User)
                .Include(a => a.Center)
                .Include(c => c.Course)
                .ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
