using AlRayan.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AlRayan.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly ApplicationDbContext _db;
        private readonly IUserService _userService;
        public UsersController(UserManager<ApplicationUser> user, RoleManager<IdentityRole> role, ApplicationDbContext db,IUserService userService)
        {
            _userManger = user;
            _roleManger = role;
            _db = db;
            _userService = userService;
            
        }
        public IActionResult Index()
        { 
            var users = _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
           if(!ModelState.IsValid) 
                return View(model);
             
            if(await _userManger.FindByEmailAsync(model.Email) is not null )
            {
                ModelState.AddModelError("Email","Email is already exists");
                return View(model);
            } 
            if(await _userManger.FindByNameAsync(model.UserName) is not null)
            {
                ModelState.AddModelError("UserName", "UserName is already exists");

                return View(model);
            }
            var user = CreateUser();
            var result =await _userService.AddNewUser(model ,user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Email", error.Description);
                }
                return View(model);

            }
            await _userManger.AddToRoleAsync(user, "Teatcher");  
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        { 
            var user = await _userManger.FindByIdAsync(userId);
            var roles =await _roleManger.Roles.ToListAsync();
            if (user == null)
                return NotFound();
            var viewModel = new UserRoleViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManger.IsInRoleAsync(user, role.Name).Result
                }).ToList()
        };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRoleViewModel model)
        {
            //model.roles have all roles
            var user = await _userManger.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();
            //only roles of this user
            var userRoles = await _userManger.GetRolesAsync(user);
            foreach (var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                {
                    await _userManger.RemoveFromRoleAsync(user, role.RoleName);
                }
                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                {
                    await _userManger.AddToRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction(nameof(Index));

        }
        public static ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

    }
}
