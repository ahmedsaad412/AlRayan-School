using AlRayan.ViewModel.Teatcher;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.Repository.Abstract
{
    public interface ITeatcherService:IBase
    {
        Task Create(AssignTeatcherForm model);
    }
}
