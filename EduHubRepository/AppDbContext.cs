﻿using EduHubEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubRepository
{
    public class AppDbContext : DbContext
    {    
        public AppDbContext(DbContextOptions<AppDbContext> options)
     : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<RestaurantAdmin> RestaurantAdmins { get; set; }
    }
}
