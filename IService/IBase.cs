using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.IService
{
    public interface IBase
    {
        IEnumerable<SelectListItem> GetSelectList();
        void Save();
    }
}
