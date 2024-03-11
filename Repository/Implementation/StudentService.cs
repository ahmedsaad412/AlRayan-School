using AlRayan.Data;
using AlRayan.Repository.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Repository.Implementation
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
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _user.Users
                 .Where(i => i.Type == Models.Type.student)
                 .Select(c => new SelectListItem { Value = c.Id, Text = c.UserName })
                 .OrderBy(c => c.Text)
                 .AsNoTracking()
                 .ToList();
        }
    }
}
