using AlRayan.Data;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Service
{
    public class UserData :IUserData
    {
        private readonly ApplicationDbContext _context;
        public UserData(ApplicationDbContext context)
        {
            _context = context;
        }
        public ApplicationUser? GetSignInUser(string userId)
        {
            return _context.Users.Where(x => x.Id == userId).FirstOrDefault();
        }
    }
}
