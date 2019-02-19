using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNHibernate.Data
{
    public class SeedData
    {
        public void Initialize(IServiceProvider serviceProvider)
        {
            INHibernateHelper nHibernateHelper = serviceProvider.GetRequiredService<INHibernateHelper>();

            using (var session = nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Query<Blog>().Delete();

                        if (!session.Query<bool>().Any())
                        {
                            session.Save(new Blog { BlogId = 1, Title = "Blog 1", SubTitle = "Blog 1 subtitle" });
                            session.Save(new Blog { BlogId = 2, Title = "Blog 2", SubTitle = "Blog 2 subtitle" });
                            session.Save(new Blog { BlogId = 3, Title = "Blog 3", SubTitle = "Blog 3 subtitle" });

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }
    }
}
