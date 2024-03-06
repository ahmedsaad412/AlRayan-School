using AlRayan.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace AlRayan.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManger;

        public UsersController(UserManager<ApplicationUser> user,RoleManager<IdentityRole> role)
        {
            _userManger = user; 
            _roleManger = role; 

        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userManger.Users.Select(user => new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                }).ToListAsync();
                
                return View(users);
            }
            catch (Exception)
            {

                throw;
            }
           

        }
        [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        {//get specific user & all roles => return userid ,
         //name and role id ,name with selected role that assigned to this user
            var user=await _userManger.FindByIdAsync(userId);
            if(user==null)
                return NotFound();
            var roles =await _roleManger.Roles.ToListAsync();
            var viewModel = new UserRoleViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManger.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };
            return View(viewModel);
        }
    }
}
 