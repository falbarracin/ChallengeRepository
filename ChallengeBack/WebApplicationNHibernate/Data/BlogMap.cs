using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNHibernate.Data
{
    public class BlogMap : ClassMap<Blog>
    {
        public BlogMap()
        {
            Table("Blog");
            LazyLoad();
            
            Id(x => x.BlogId).GeneratedBy.Identity();
            Map(x => x.DateTimeAdd);
            Map(x => x.SubTitle);
            Map(x => x.Title);
        }
    }
}
