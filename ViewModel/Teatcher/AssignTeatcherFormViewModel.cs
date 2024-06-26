﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.ViewModel.Teatcher
{
    public class AssignTeatcherFormViewModel
    {
        public bool IsMarried { get; set; }
        public string Id { get; set; }
        public IEnumerable<SelectListItem> Teatchers{ get; set; }=Enumerable.Empty<SelectListItem>();
        public int CenterId { get; set; }
        public IEnumerable<SelectListItem> Centers { get; set; } = Enumerable.Empty<SelectListItem>();
        public int CourseId { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
