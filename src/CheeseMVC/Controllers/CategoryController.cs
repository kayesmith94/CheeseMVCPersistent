using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.Data;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
            /*This creates a private field context of type CheeseDbContext. This object will be the mechanism with which we interact 
             * with objects stored in the database. 
             * The MVC framework will do the work of creating an instance of CheeseDbContext and 
             * passing it into our controller's constructor.
             * 
             * This code would need to be added to each controller class that you want 
             * to have access to the persistent collections defined within CheeseDbContext. */

             List<CheeseCategory> cheesecatobjs = context.Categories.ToList();// is this where I do this? how does index know about context?
        }

        public IActionResult Index()
        {
            List<CheeseCategory> cheesecatobjs = context.Categories.ToList();//
            return View(cheesecatobjs);
        }
    }
}