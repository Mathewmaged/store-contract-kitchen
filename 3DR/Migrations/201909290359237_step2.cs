namespace _3DR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nha2y", "mfslatNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Nha2y", "mgaryNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Nha2y", "totalmfslat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Nha2y", "totalmgary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.abtda2y", "dolfColor");
            DropColumn("dbo.Nha2y", "dolfColor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nha2y", "dolfColor", c => c.Int(nullable: false));
            AddColumn("dbo.abtda2y", "dolfColor", c => c.Int(nullable: false));
            DropColumn("dbo.Nha2y", "totalmgary");
            DropColumn("dbo.Nha2y", "totalmfslat");
            DropColumn("dbo.Nha2y", "mgaryNumber");
            DropColumn("dbo.Nha2y", "mfslatNumber");
        }
    }
}
