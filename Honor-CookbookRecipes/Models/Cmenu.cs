using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honor_CookbookRecipes.Models
{
    public class Cmenu
    {
        public int CmenuId { get; set; }
        public string DishName { get; set; }
        public string Prices { get; set; }
        public string PictureUrl { get; set; }
        public string Name { get; set; }
        public List<Scart> Scarts { get; set; }
    }
}
