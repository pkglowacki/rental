namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kosztnotnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zamówienie", "KosztZamówienia", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zamówienie", "KosztZamówienia", c => c.Decimal(storeType: "money"));
        }
    }
}
