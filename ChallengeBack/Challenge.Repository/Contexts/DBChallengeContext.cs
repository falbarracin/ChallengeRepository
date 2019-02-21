using Challenge.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlServerCe;
using System.Data.SQLite;

namespace Challenge.Repository.Contexts
{
    public class DBChallengeContext: DbContext, IDBChallengeContext
    {   

        public DBChallengeContext() : 
            base(new SqlCeConnectionStringBuilder() { DataSource = "C:\\Databases\\SQLiteWithEF.db" }.ConnectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

    }
}
