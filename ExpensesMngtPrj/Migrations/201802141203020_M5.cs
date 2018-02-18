namespace SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "customer_ID", "dbo.Customers");
            DropIndex("dbo.Expenses", new[] { "customer_ID" });
            DropTable("dbo.Expenses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Description = c.String(),
                        customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Expenses", "customer_ID");
            AddForeignKey("dbo.Expenses", "customer_ID", "dbo.Customers", "ID");
        }
    }
}
