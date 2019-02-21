namespace Challenge.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createSQLLite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IdValue = c.String(nullable: false, maxLength: 128),
                        Gender = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Uuid = c.String(),
                        UserName = c.String(),
                        Location_State = c.String(),
                        Location_Street = c.String(),
                        Location_City = c.String(),
                        Location_PostCode = c.String(),
                    })
                .PrimaryKey(t => t.IdValue);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
