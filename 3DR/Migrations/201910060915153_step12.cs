namespace _3DR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.abtda2y", "m2bd", c => c.String());
            AlterColumn("dbo.Nha2y", "m2bd", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nha2y", "m2bd", c => c.Int(nullable: false));
            AlterColumn("dbo.abtda2y", "m2bd", c => c.Int(nullable: false));
        }
    }
}
