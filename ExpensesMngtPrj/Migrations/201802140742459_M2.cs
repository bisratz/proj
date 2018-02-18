namespace SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Expenses", "customer_ID", c => c.Int());
            CreateIndex("dbo.Expenses", "customer_ID");
            AddForeignKey("dbo.Expenses", "customer_ID", "dbo.Customers", "ID");
            DropColumn("dbo.Expenses", "Amount");
            DropColumn("dbo.Expenses", "Category");
            DropColumn("dbo.Expenses", "SubCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "SubCategory", c => c.String());
            AddColumn("dbo.Expenses", "Category", c => c.String());
            AddColumn("dbo.Expenses", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Expenses", "customer_ID", "dbo.Customers");
            DropIndex("dbo.Expenses", new[] { "customer_ID" });
            DropColumn("dbo.Expenses", "customer_ID");
            DropColumn("dbo.Expenses", "Time");
        }
    }
}
