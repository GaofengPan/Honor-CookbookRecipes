using System;
using System.Collections.Generic;
using System.Text;
using Honor_CookbookRecipes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Honor_CookbookRecipes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cmenu> Cmenus { get; set; }
        public DbSet<Scart> Scarts { get; set; }
    }
}
