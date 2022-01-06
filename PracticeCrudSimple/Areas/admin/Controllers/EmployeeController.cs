using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeCrudSimple.Data;
using PracticeCrudSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeCrudSimple.Areas.admin.Controllers
{
    [Area("admin")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {

            return View(_context.Employees.Include(e=>e.Position).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {

            if (ModelState.IsValid)
            {
                _context.Employees.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
