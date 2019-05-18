﻿using Honor_CookbookRecipes.Models;
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
                DishName = "LeBron",
                CmenuName = context.Cmenus.Find("Cantoneses cuisine").Name,
                Prices = "$20"
            },
            new Dish {
                DishName = "Kevin",
                CmenuName = context.Cmenus.Find("Sichuan cuisine").Name,
                Prices = "$20"
            },
            new Dish {
                DishName = "Stephen",
                CmenuName = context.Cmenus.Find("Shandong cuisine").Name,
                Prices = "$20"
            },
            new Dish {
                DishName = "James",
                CmenuName = context.Cmenus.Find("Jiangsu cuisine").Name,
                Prices = "$20"
            },
            new Dish {
                DishName = "James",
                CmenuName = context.Cmenus.Find("Snacks").Name,
                Prices = "$20"
            },
            new Dish {
                DishName = "James",
                CmenuName = context.Cmenus.Find("Drink").Name,
                Prices = "$20"
            },
        };

            return Dishes;
        }
    }
}