using CheeseMVC.Data;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CheeseMVC.ViewModels
{
    public class AddItemViewModel
    {
        public Menu Menu { get; set; }
        public List<SelectListItem> Cheeses { get; set; } = new List<SelectListItem>();
        [Display(Name ="Cheese Options")]
        public int CheeseID { get; set; }
        public int MenuID { get; set; }

        public AddItemViewModel(){        }

        public AddItemViewModel(Menu menu, IList<Cheese> cheeses)
        {
            foreach (var cheese in cheeses)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = cheese.ID.ToString(),
                    Text=cheese.Name
                });
            }
            Menu = menu;
        }
    }
}