using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEntityFramework.Data
{
    public class SeedData
    {
        public void Initialize(IServiceProvider serviceProvider)
        {
            DbContextOptions<MyDbContext> ortWorkshopContext = serviceProvider.GetRequiredService<DbContextOptions<MyDbContext>>();

            using (var dbContext = new MyDbContext(ortWorkshopContext))
            {
                //Ensure database is created
                dbContext.Database.EnsureCreated();

                if (!dbContext.Blogs.Any())
                {
                    dbContext.Blogs.AddRange(new Blog[]
                        {
                             new Blog{ BlogId=1, Title="Blog 1", SubTitle="Blog 1 subtitle" },
                             new Blog{ BlogId=2, Title="Blog 2", SubTitle="Blog 2 subtitle" },
                             new Blog{ BlogId=3, Title="Blog 3", SubTitle="Blog 3 subtitle" }
                        });
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
