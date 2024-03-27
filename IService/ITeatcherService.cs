using AlRayan.Models.MainEntity;

namespace AlRayan.IService
{
    public interface ITeatcherService : IBase
    {
        
        Teatcher? GetById(int id);
        public IEnumerable<ApplicationUser> GetSelectListDistinct();
        Task Create(AssignTeatcherFormViewModel model);
        Task<Teatcher?> Update(EditTeatcherFormViewModel model);
        IEnumerable<Teatcher>? GetAllTeatchers();
    }
}
