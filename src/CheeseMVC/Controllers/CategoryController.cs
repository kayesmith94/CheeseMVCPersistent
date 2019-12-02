using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
            /* 
             * This code would need to be added to each controller class that you want 
             * to have access to the persistent collections defined within CheeseDbContext. */
        }

        public IActionResult Index()
        {
            IList<CheeseCategory> categories = context.Categories.ToList();//
            return View(categories);
        }

        public IActionResult Add()
        {
            return View();       
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryVCM)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryVCM.Name
                };
                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }
            else
            { 
                return View(); 
            }
        }
    }
}