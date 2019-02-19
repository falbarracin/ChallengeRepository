using System;

namespace WebApplicationNHibernate.Data
{
    public class Blog
    {
        public virtual int BlogId { get; set; }

        public virtual string Title { get; set; }

        public virtual string SubTitle { get; set; }

        public virtual DateTime DateTimeAdd { get; set; }
    }
}
