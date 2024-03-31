using Microsoft.AspNetCore.Identity;

namespace AlRayan.IService
{
    public interface IUserService
    {
        Task< IdentityResult> AddNewUser(AddUserViewModel model ,ApplicationUser user);
        List<UserViewModel> GetAllUsers();
    }
}
