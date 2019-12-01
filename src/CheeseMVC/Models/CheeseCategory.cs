using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseCategory
    {
        public string Name { get; set; }
        public int ID { get; private set; }
        private int nextID = 1;
    }
}
