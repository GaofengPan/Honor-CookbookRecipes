using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honor_CookbookRecipes.Models
{
    public class Cmenu
    {
        public int CmenuId { get; set; }
        public string Name { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
