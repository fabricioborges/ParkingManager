namespace ParkingManager.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DurationPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbPayment", "Duration", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.TbPayment", "ExitTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TbPayment", "ExitTime", c => c.Time(precision: 7));
            DropColumn("dbo.TbPayment", "Duration");
        }
    }
}
