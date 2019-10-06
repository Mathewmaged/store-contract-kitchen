namespace _3DR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.abtda2y", "Phone", c => c.String());
            AlterColumn("dbo.Nha2y", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nha2y", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.abtda2y", "Phone", c => c.Int(nullable: false));
        }
    }
}
