namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Urządzenie",
                c => new
                    {
                        UrządzenieId = c.Int(nullable: false, identity: true),
                        NazwaUrządzenia = c.String(),
                        MiesięcznyKosztWypożyczenia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UrządzenieId);
            
            CreateTable(
                "dbo.Zamówienie",
                c => new
                    {
                        ZamówienieId = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Ulica = c.String(),
                        NumerDomu = c.Int(nullable: false),
                        NumerMieszkania = c.Int(nullable: false),
                        KosztZamówienia = c.Decimal(nullable: false, storeType: "money"),
                        IlośćMiesięcyWypożyczenia = c.Int(nullable: false),
                        DataZłożenia = c.DateTime(nullable: false),
                        DataZwrotu = c.DateTime(nullable: false),
                        UrządzenieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZamówienieId)
                .ForeignKey("dbo.Urządzenie", t => t.UrządzenieId, cascadeDelete: true)
                .Index(t => t.UrządzenieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zamówienie", "UrządzenieId", "dbo.Urządzenie");
            DropIndex("dbo.Zamówienie", new[] { "UrządzenieId" });
            DropTable("dbo.Zamówienie");
            DropTable("dbo.Urządzenie");
        }
    }
}
