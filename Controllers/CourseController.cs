﻿using AlRayan.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        
        {
            
            var courses =_db.Courses.Include(c=>c.Center)
                .ThenInclude(t=>t.User)
                
                .ToList();
            return View(courses);
        }
    }
}
