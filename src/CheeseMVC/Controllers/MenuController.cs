using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
            /* 
             * This code would need to be added to each controller class that you want 
             * to have access to the persistent collections defined within CheeseDbContext. */
        }

        public IActionResult Index()
        {
            IList<Menu> menus = context.Menus.ToList();
            return View(menus);
        }

        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);       
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuVCM)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuVCM.Name
                };
                context.Menus.Add(newMenu);
                context.SaveChanges();
                return Redirect("/Menu"); 
            }
            else
            { 
               return View(addMenuVCM); 
            }
        }

        public IActionResult ViewMenu(int id)
        {

            List<CheeseMenu> items = context
                .CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id)
                .ToList();

            Menu menu = context.Menus.First(m => m.ID == id);
            ViewMenuViewModel viewModel = new ViewMenuViewModel
            {
                Menu = menu,
                Items = items
            };
            return View(viewModel);
        }
        public IActionResult AddItem(int id)
        {
            IList<Cheese> cheeses = context.Cheeses.ToList();
            Menu menu = context.Menus.Single(m => m.ID == id);
            return View(new AddItemViewModel(menu, cheeses));
        }

        [HttpPost]
        public IActionResult AddItem(AddItemViewModel addItemVM)
        {
            if(ModelState.IsValid)
            {
                var cheeseID = addItemVM.CheeseID;
                var menuID = addItemVM.MenuID;

                //checks to make sure we don't add the same item twice into data and get db exception
                IList<CheeseMenu> existingItems = context.CheeseMenus
                    .Where(cm => cm.CheeseID == cheeseID)
                    .Where(cm => cm.MenuID == menuID).ToList();

                if (existingItems.Count==0)
                {
                    CheeseMenu menuItem = new CheeseMenu
                    {
                        Cheese = context.Cheeses.Single(c => c.ID == cheeseID),
                        Menu = context.Menus.Single(m => m.ID == menuID)
                    };
                    context.CheeseMenus.Add(menuItem);
                    context.SaveChanges();
                }
                return Redirect(string.Format("/Menu/ViewMenu/{0}", addItemVM.MenuID));
            }

            return View(addItemVM);
        }
    }
}