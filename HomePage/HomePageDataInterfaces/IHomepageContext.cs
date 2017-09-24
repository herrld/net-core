using HomePageDataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomePageDataInterfaces
{
    public interface IHomepageContext
    {
        DbSet<HomepageUser> Users { get; set; }
        
        int SaveChanges();
       
        int SaveChanges(bool acceptAllChangesOnSuccess);
       
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

    }
}
