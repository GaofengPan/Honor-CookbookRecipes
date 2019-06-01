using Honor_CookbookRecipes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honor_CookbookRecipes.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any Cmenus.
                if (context.Cmenus.Any())
                {
                    return;   // DB has already been seeded
                }

                var Cmenus = DummyData.GetCmenus().ToArray();
                context.Cmenus.AddRange(Cmenus);
                context.SaveChanges();

                var Scarts = DummyData.GetScarts(context).ToArray();
                context.Scarts.AddRange(Scarts);
                context.SaveChanges();
            }
        }

        public static List<Cmenu> GetCmenus()
        {
            List<Cmenu> Cmenus = new List<Cmenu>() {
            new Cmenu() {
                DishName = "Roast goose",
                Prices = "$30",
                Name="Cantoneses cuisine",
                PictureUrl="images/rd.jpg"
            },
            new Cmenu() {
                DishName = "Spicy Chicken",
                Prices = "$25",
                Name="Sichuan cuisine",
                PictureUrl="images/chicken.jpg"

            },
            new Cmenu() {
                DishName = "Hotpot",
                Prices = "$50",
                Name="Sichuan cuisine",
                PictureUrl="images/hp.jpg"

            },
            new Cmenu() {
                DishName = "Spring roll",
                Prices = "$10",
                Name = "Shandong cuisine",
                PictureUrl="images/roll.jpg"
            },
            new Cmenu() {
                DishName = "Salted duck",
                Prices = "$25",
                Name = "Jiangsu cuisine",
                PictureUrl="images/sduck.jpg"
            },
            new Cmenu() {
                DishName = "Dim sum",
                Prices = "$20",
                Name="Snacks",
                PictureUrl="/images/dimsum.jpg" 
            },
            new Cmenu() {
                DishName = "Apple Juice",
                Prices = "$10",
                Name = "Drink",
                PictureUrl="/images/apple.jpg"
            },
        };

            return Cmenus;
        }

        public static List<Scart> GetScarts(ApplicationDbContext context)
        {
            List<Scart> Scarts = new List<Scart>() {
            new  Scart {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Cantoneses cuisine").CmenuId,
                DishName = "Roast goose",
                Prices = "$30"
            },
            new  Scart {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Sichuan cuisine").CmenuId,
                DishName = "Spicy Chicken",
                Prices = "$25"
            },
            new  Scart {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Sichuan cuisine").CmenuId,
                DishName = "Hotpot",
                Prices = "$50"
            },
            new  Scart {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Shandong cuisine").CmenuId,
                DishName = "Spring roll",
                Prices = "$10"
            },
            new  Scart {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Jiangsu cuisine").CmenuId,
                DishName = "Salted duck",
                Prices = "$25"
            },
            new  Scart {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Snacks").CmenuId,
                DishName = "Dim sum",
                Prices = "$20"
            },
            new  Scart{
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Drink").CmenuId,
                DishName = "Apple Juice",
                Prices = "$10"
            },
        };

            return Scarts;
        }
    }
}
