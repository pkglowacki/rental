namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edycjanotnullwmodeluzamówieniev2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zamówienie", "Imie", c => c.String(nullable: false));
            AlterColumn("dbo.Zamówienie", "Nazwisko", c => c.String(nullable: false));
            AlterColumn("dbo.Zamówienie", "Ulica", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zamówienie", "Ulica", c => c.String());
            AlterColumn("dbo.Zamówienie", "Nazwisko", c => c.String());
            AlterColumn("dbo.Zamówienie", "Imie", c => c.String());
        }
    }
}
