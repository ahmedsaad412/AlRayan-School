﻿using AlRayan.Models.MainEntity;
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

        public Type Type { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Photo { get; set; } = string.Empty;

        ///relation 1-1 for all users
        public Center  Center { get; set; }

        public Student  Student{ get; set; }
        public Teatcher Teatcher{ get; set; }

    }

    public enum Type
    {
        admin =1,
        teatcher=2,
        student=3
    }  
    public enum Statues
    {
        True =0,
        False=1
       
    }
}
