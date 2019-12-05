using CheeseMVC.Data;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CheeseMVC.ViewModels
{
    public class AddMenuViewModel
    {

        [Required]
        [Display(Name = "Menu Name")]
        public string Name { get; set; }
    }
}