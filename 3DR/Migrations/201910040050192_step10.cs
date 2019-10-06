namespace _3DR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.abtda2yArkam", "Arkam", c => c.String());
            AlterColumn("dbo.ArkamM2bd", "Arkam", c => c.String());
            AlterColumn("dbo.dolfColors", "Color", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.dolfColors", "Color", c => c.Int(nullable: false));
            AlterColumn("dbo.ArkamM2bd", "Arkam", c => c.Int(nullable: false));
            AlterColumn("dbo.abtda2yArkam", "Arkam", c => c.Int(nullable: false));
        }
    }
}
