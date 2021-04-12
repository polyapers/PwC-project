using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Controllers;

namespace WebApplication1.Views.Home
{
    public class CreateModel : PageModel
    {
        ApplicationContext db;

        public CreateModel(ApplicationContext db)
        {
            this.db = db;
        }

        public IEnumerable<Person> personNames;

        public void OnGet()
        {
            personNames = db.Persons.ToList();
        }


        //public IList<Person> personNames { get; set; }

        //public async Task OnGetAsync()
        //{
        //    personNames = await this.db.Persons.ToListAsync();
        //}

        //public async Task<IActionResult> OnPostAsync()
        //{
            
        //    personNames = await this.db.Persons.ToListAsync();
            

        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    return NotFound();
        //}
    }
 
}
