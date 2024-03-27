namespace AlRayan.IService
{
    public interface IUserData
    {
        ApplicationUser? GetSignInUser(string id);

    }
}
