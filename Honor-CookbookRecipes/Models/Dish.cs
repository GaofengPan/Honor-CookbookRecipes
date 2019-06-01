using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honor_CookbookRecipes.Models
{
    public class Dish
    {
        public int DishId { get; set; }

        public string DishName { get; set; }

        public string CmenuName { get; set; }
        public string Prices { get; set; }

        public string PictureUrl { get; set; }

        public int CmenuId { get; set; }
        public Cmenu Cmenu { get; set; }


    }
}
