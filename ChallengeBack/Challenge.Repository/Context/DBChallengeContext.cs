using Challenge.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Context
{
    public class DBChallengeContext: DbContext
    {
        public DBChallengeContext() : base("MyDbChallenge")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
