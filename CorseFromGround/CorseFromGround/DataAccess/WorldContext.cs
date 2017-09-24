﻿using CouseFromGround.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorseFromGround.DataAccess
{
    public class WorldContext : IdentityDbContext<WorldUser>
    {
        private IConfigurationRoot config;
        public WorldContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            this.config = config;
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(this.config["ConnectionStrings:WorldContextConnection"]);
        }
    }
}