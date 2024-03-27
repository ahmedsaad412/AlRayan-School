
using AlRayan.Data;
using Microsoft.AspNetCore.Identity;

namespace AlRayan.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHost;
        private readonly string _imagePath;
        public UserService(RoleManager<IdentityRole> roleManager ,UserManager<ApplicationUser> userManager , ApplicationDbContext context , IWebHostEnvironment webHost)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _webHost = webHost;
            _imagePath = $"{_webHost.WebRootPath}{FileSettings.FilePath}";

        }

        public async Task<IdentityResult> AddNewUser(AddUserViewModel model, ApplicationUser user)
        {
            var photoName = await SavePhoto(model.Photo);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Photo = photoName;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Type = Models.Type.teatcher;

            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public List<RoleViewModel> GetAllRoles(ApplicationUser user)
        {
           return _roleManager.Roles.Select(role => new RoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
            }).ToList();
        }
        public List<UserViewModel> GetAllUsers()
        {
            return _context.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Roles = _userManager.GetRolesAsync(user).Result,
            }).ToList();
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
