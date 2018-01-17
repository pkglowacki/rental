namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edycjamodelikluczy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Zamówienie", "UrządzenieId", "dbo.Urządzenie");
            DropPrimaryKey("dbo.Urządzenie");
            DropColumn("dbo.Urządzenie", "UrządzenieId");
            AddColumn("dbo.Urządzenie", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Urządzenie", "Id");
            AddForeignKey("dbo.Zamówienie", "UrządzenieId", "dbo.Urządzenie", "Id", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Urządzenie", "UrządzenieId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Zamówienie", "UrządzenieId", "dbo.Urządzenie");
            DropPrimaryKey("dbo.Urządzenie");
            DropColumn("dbo.Urządzenie", "Id");
            AddPrimaryKey("dbo.Urządzenie", "UrządzenieId");
            AddForeignKey("dbo.Zamówienie", "UrządzenieId", "dbo.Urządzenie", "UrządzenieId", cascadeDelete: true);
        }
    }
}
