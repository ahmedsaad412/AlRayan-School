using System.ComponentModel.DataAnnotations;

namespace AlRayan.ViewModel
{
    public class RoleFormViewModel
    {
        [Required,StringLength(100)]
        public string Name { get; set; }
    }
}
