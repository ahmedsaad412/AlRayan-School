using AlRayan.Models.MainEntity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlRayan.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required,MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]

        public string LastName { get; set; }

        public string Photo { get; set; } = string.Empty;

        ///relation 1-1 for all users
        [ForeignKey(nameof(Center))]
        public int? CenterId { get; set; }
        public Center  Center { get; set; }

        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }
        public Student  Student{ get; set; }
        [ForeignKey(nameof(Teatcher))]
        public int? TeatcherId { get; set; }
        public Teatcher Teatcher{ get; set; }

    }
}
