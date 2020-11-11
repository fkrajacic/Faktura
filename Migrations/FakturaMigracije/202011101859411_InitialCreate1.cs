namespace Faktura.Migrations.FakturaMigracije
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Racuns", "ModifiedBy", c => c.String());
            DropColumn("dbo.Racuns", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Racuns", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Racuns", "ModifiedBy");
        }
    }
}
