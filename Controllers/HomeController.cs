using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ViewProcesses()
        {
            return View(await db.Processes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            db.Persons.Add(person);
            await db.SaveChangesAsync();
            return RedirectToAction("DBwatch");
        }

        public IActionResult CreateProcess()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProcess(Models.Process process)
        {
            db.Processes.Add(process);
            await db.SaveChangesAsync();
            return RedirectToAction("ViewProcceses");
        }

        //[HttpGet]
        //[ActionName("Details")]
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //        return NotFound(); 

        //    Person person = await db.Persons
        //        .Include(s => s.Processes)
        //        //.ThenInclude(e => e.Process)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(p => p.Id == id);

        //     if (person != null)
        //        return NotFound();

        //    return View(person);


        //}

        //[HttpGet]
        //[ActionName("Details")]
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id != null)
        //    {
        //        Person person = await db.Persons.FirstOrDefaultAsync(p => p.Id == id);
        //        if (person != null)
        //            return View(person);
        //    }
        //    return NotFound();
        //}

        public IActionResult Details(int id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person != null)
            {
                return View(person);
            }
            return NotFound();
        }

        public async Task<IActionResult> DBwatch(string sortOrder)
        {
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewData["AgeSortParam"] = sortOrder == "age" ? "ageDesc" : "age";
            //ViewData["CompSortParam0"] = String.IsNullOrEmpty(sortOrder) ? "compDesc" : "";
            var people = from s in db.Persons select s;

            switch (sortOrder)
            {
                case "nameDesc":
                    people = people.OrderByDescending(s => s.Name);
                    break;
                //case "compDesc":
                //    people = people.OrderByDescending(s => s.Company);
                //    break;
                case "age":
                    people = people.OrderBy(s => s.Age);
                    break;
                case "ageDesc":
                    people = people.OrderByDescending(s => s.Age);
                    break;
                default:
                    people = people.OrderBy(s => s.Name);
                    break;
            }

            return View(await people.AsNoTracking().ToListAsync());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Person person = await db.Persons.FirstOrDefaultAsync(p => p.Id == id);
                if (person != null)
                    return View(person);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            db.Persons.Update(person);
            await db.SaveChangesAsync();
            return RedirectToAction("DBwatch");
        }


        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Person person = await db.Persons.FirstOrDefaultAsync(p => p.Id == id);
                if (person != null)
                    return View(person);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Person user = await db.Persons.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.Persons.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("DBwatch");
                }
            }
            return NotFound();
        }
    }
}