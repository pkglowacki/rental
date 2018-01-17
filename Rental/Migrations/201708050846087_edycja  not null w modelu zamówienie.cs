namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edycjanotnullwmodeluzamówienie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zamówienie", "KosztZamówienia", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Zamówienie", "DataZwrotu", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zamówienie", "DataZwrotu", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Zamówienie", "KosztZamówienia", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
