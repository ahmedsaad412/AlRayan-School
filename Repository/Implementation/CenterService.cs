using AlRayan.Data;
using AlRayan.Repository.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Repository.Implementation
{
    public class CenterService : ICenterService
    {
        private readonly ApplicationDbContext _context;
        public CenterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Centers.
                Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CenterName })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
