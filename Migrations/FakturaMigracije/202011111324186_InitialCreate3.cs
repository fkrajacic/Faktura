namespace Faktura.Migrations.FakturaMigracije
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stavkas", "RacunId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stavkas", "RacunId", c => c.String());
        }
    }
}
