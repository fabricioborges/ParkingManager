namespace ParkingManager.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TbPrice",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InitialValue = c.Single(nullable: false),
                        AdditionalValue = c.Single(nullable: false),
                        InitialDate = c.DateTime(nullable: false),
                        FinalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TbVehicles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicensePlate = c.String(nullable: false),
                        Input = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TbVehicles");
            DropTable("dbo.TbPrice");
        }
    }
}
