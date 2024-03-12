using AlRayan.Models.MainEntity;
using AlRayan.ViewModel.Teatcher;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.Repository.Abstract
{
    public interface ITeatcherService:IBase
    {
        Task Create(AssignTeatcherForm model);
        Teatcher? GetById(int id);
        Task<Teatcher?> Update(EditTeatcherForm model);

    }
}
