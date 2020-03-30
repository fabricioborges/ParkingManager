namespace ParkingManager.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TbPayment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VehicleId = c.Long(nullable: false),
                        PriceId = c.Long(nullable: false),
                        ExitTime = c.Time(precision: 7),
                        Value = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TbPrice", t => t.PriceId, cascadeDelete: true)
                .ForeignKey("dbo.TbVehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.PriceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TbPayment", "VehicleId", "dbo.TbVehicles");
            DropForeignKey("dbo.TbPayment", "PriceId", "dbo.TbPrice");
            DropIndex("dbo.TbPayment", new[] { "PriceId" });
            DropIndex("dbo.TbPayment", new[] { "VehicleId" });
            DropTable("dbo.TbPayment");
        }
    }
}
