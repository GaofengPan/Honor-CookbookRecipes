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

                var Dishes = DummyData.GetDishes(context).ToArray();
                context.Dishes.AddRange(Dishes);
                context.SaveChanges();
            }
        }

        public static List<Cmenu> GetCmenus()
        {
            List<Cmenu> Cmenus = new List<Cmenu>() {
            new Cmenu() {
                Name="Cantoneses cuisine",
            },
            new Cmenu() {
                Name="Sichuan cuisine",
            },
            new Cmenu() {
                Name="Shandong cuisine",
            },
            new Cmenu() {
                Name="Jiangsu cuisine",
            },
            new Cmenu() {
                Name="Snacks",
            },
            new Cmenu() {
                Name="Drink",
            },
        };

            return Cmenus;
        }

        public static List<Dish> GetDishes(ApplicationDbContext context)
        {
            List<Dish> Dishes = new List<Dish>() {
            new Dish {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Cantoneses cuisine").CmenuId,
                DishName = "Roast goose",
                CmenuName = "Cantoneses cuisine",
                Prices = "$25",
                PictureUrl="/images/rd.jpg"
            },
            new Dish {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Sichuan cuisine").CmenuId,
                DishName = "Spicy Chicken",
                CmenuName = "Sichuan cuisine",
                Prices = "$20",
                PictureUrl="/images/chicken.jpg"
            },
            new Dish {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Sichuan cuisine").CmenuId,
                DishName = "Hotpot",
                CmenuName ="Sichuan cuisine",
                Prices = "$50",
                PictureUrl="images/hp.jpg"
            },
            new Dish {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Shandong cuisine").CmenuId,
                DishName = "Spring roll",
                CmenuName = "Shandong cuisine",
                Prices = "$20",
                PictureUrl="/images/roll.jpg"
            },
            new Dish {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Jiangsu cuisine").CmenuId,
                DishName = "Salted duck",
                CmenuName = "Jiangsu cuisine",
                Prices = "$25",
                PictureUrl="images/sduck.jpg"
            },
            new Dish {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Snacks").CmenuId,
                DishName = "Dim sum",
                CmenuName = "Snacks",
                Prices = "$30",
                PictureUrl="/images/dimsum.jpg"
            },
            new Dish {
                CmenuId=context.Cmenus.FirstOrDefault(c =>c.Name== "Drink").CmenuId,
                DishName = "Apple Juice",
                CmenuName = "Drink",
                Prices = "$10",
                PictureUrl="/images/apple.jpg"
            },
        };

            return Dishes;
        }
    }
}
