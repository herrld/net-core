using HomePageDataInterfaces;
using HomePageDataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDataAccess
{
    public class HomepageContext : IdentityDbContext<HomepageUser>, IHomepageContext
    {
        private IConfigurationRoot config;

        public HomepageContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(this.config["ConnectionStrings:HomepageConnection"]);
        }
    }
}
