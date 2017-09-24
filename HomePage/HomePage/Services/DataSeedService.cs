using HomePageDataInterfaces;
using HomePageDataModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePage.Services
{
    public class DataSeedService
    {
        private UserManager<HomepageUser> userManger;
        private IHomepageContext context;

        public DataSeedService(IHomepageContext context, UserManager<HomepageUser> userManager)
        {
            this.userManger = userManager;
            this.context = context;
            
        }

        public async Task SeedData()
        {
            await this.seedUsers();
        }

        private async Task seedUsers()
        {
            string rootUserEmail = "bainon25@gmail.com";
            if(await this.userManger.FindByEmailAsync(rootUserEmail) == null)
            {
                var user = new HomepageUser()
                {
                    UserName = "Lee",
                    Email = rootUserEmail
                };
                var result = await this.userManger.CreateAsync(user,"p@assword");
                var a = result.Succeeded;
            }
        }
    }
}
