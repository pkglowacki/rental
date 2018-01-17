namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodaniestatusudostępnościurządzenia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urządzenie", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urządzenie", "Status");
        }
    }
}
