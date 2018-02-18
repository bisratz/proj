namespace SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "worker_ID", c => c.Int());
            CreateIndex("dbo.Appointments", "worker_ID");
            AddForeignKey("dbo.Appointments", "worker_ID", "dbo.Workers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "worker_ID", "dbo.Workers");
            DropIndex("dbo.Appointments", new[] { "worker_ID" });
            DropColumn("dbo.Appointments", "worker_ID");
        }
    }
}
