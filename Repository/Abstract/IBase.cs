using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.Repository.Abstract
{
    public interface IBase
    {
        IEnumerable<SelectListItem> GetSelectList();

    }
}
