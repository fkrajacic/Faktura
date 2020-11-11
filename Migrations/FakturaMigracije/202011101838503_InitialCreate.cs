namespace Faktura.Migrations.FakturaMigracije
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Racuns",
                c => new
                    {
                        BrojFakture = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DateNow = c.DateTime(nullable: false),
                        DatumDospijeca = c.DateTime(nullable: false),
                        UkupnaCijenaBezPoreza = c.Double(nullable: false),
                        UkupnaCijenaSPorezom = c.Double(nullable: false),
                        NazivPrimateljaRacuna = c.String(),
                    })
                .PrimaryKey(t => t.BrojFakture);
            
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        IdStavka = c.Int(nullable: false, identity: true),
                        OpisProdaneStavke = c.String(),
                        KolicinaProdaneStavke = c.Int(nullable: false),
                        CijenaStavkeBezPoreza = c.Double(nullable: false),
                        UkupnaCijenaStavkaBezPoreza = c.Double(nullable: false),
                        RacunId = c.String(),
                        Racun_BrojFakture = c.Int(),
                    })
                .PrimaryKey(t => t.IdStavka)
                .ForeignKey("dbo.Racuns", t => t.Racun_BrojFakture)
                .Index(t => t.Racun_BrojFakture);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stavkas", "Racun_BrojFakture", "dbo.Racuns");
            DropIndex("dbo.Stavkas", new[] { "Racun_BrojFakture" });
            DropTable("dbo.Stavkas");
            DropTable("dbo.Racuns");
        }
    }
}
