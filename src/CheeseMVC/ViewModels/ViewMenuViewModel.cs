using CheeseMVC.Data;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CheeseMVC.ViewModels
{
    public class ViewMenuViewModel
    {

        public IList<CheeseMenu>  Items { get; set; }
        public Menu Menu { get; set; }
    }
}