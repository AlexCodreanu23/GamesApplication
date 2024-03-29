﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Game> Games {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication3.Models.Developers>? Developers { get; set; }
        public DbSet<WebApplication3.Models.Users>? Users { get; set; }
        public DbSet<WebApplication3.Models.Reviews>? Reviews { get; set; }
        public DbSet<WebApplication3.Models.SystemRequirements>? SystemRequirements { get; set; }


    }
}