﻿using AlRayan.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.ViewModel.Course
{
    public class AssignCourseFormViewModel
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }

        [AllowedExtentionsAttribute(FileSettings.AllowedExtentions)]
        [MaxFileSizeAttribute(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Photo { get; set; }

        public int CenterId { get; set; }
        public IEnumerable<SelectListItem> Centers { get; set; } = Enumerable.Empty<SelectListItem>();

        #region when assign teatchers to specific course
        //public List<string> SelectedTeatchers { get; set; } = default!;

        //public IEnumerable<SelectListItem> Teatchers { get; set; } = Enumerable.Empty<SelectListItem>();
        //public List<string> SelectedStudents { get; set; } = new List<string>();
        //public IEnumerable<SelectListItem> Students { get; set; } = Enumerable.Empty<SelectListItem>(); 
        #endregion


    }
}
