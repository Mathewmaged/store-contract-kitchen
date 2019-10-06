namespace _3DR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.abtda2y",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        clientAddress = c.String(),
                        PlaceAddress = c.String(),
                        Phone = c.Int(nullable: false),
                        nationalId = c.String(),
                        totalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalPriceText = c.String(),
                        dof3aMokdma = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dof3aMokdmaText = c.String(),
                        tare5t3akod = c.String(),
                        modelElmtb5 = c.String(),
                        meterPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        metersNumber = c.Int(nullable: false),
                        mfslatNumber = c.Int(nullable: false),
                        mgaryNumber = c.Int(nullable: false),
                        totalmetermatb5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalmfslat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalmgary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        modelelmfslat = c.String(),
                        mfslatPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        modelMgary = c.String(),
                        mgaryPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dolfColor = c.Int(nullable: false),
                        da5ly = c.String(),
                        m2bd = c.Int(nullable: false),
                        Notes = c.String(),
                        totalAccessories = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.abtda2yArkam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Arkam = c.Int(nullable: false),
                        Abtda2YId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.abtda2y", t => t.Abtda2YId, cascadeDelete: true)
                .Index(t => t.Abtda2YId);
            
            CreateTable(
                "dbo.abtda2yAcces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Abtda2YId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.abtda2y", t => t.Abtda2YId, cascadeDelete: true)
                .Index(t => t.Abtda2YId);
            
            CreateTable(
                "dbo.Accesories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Nha2Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nha2y", t => t.Nha2Id, cascadeDelete: true)
                .Index(t => t.Nha2Id);
            
            CreateTable(
                "dbo.Nha2y",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        clientAddress = c.String(),
                        PlaceAddress = c.String(),
                        Phone = c.Int(nullable: false),
                        nationalId = c.String(),
                        totalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalPriceText = c.String(),
                        dof3aMokdma = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dof3aMokdmaText = c.String(),
                        tare5t3akod = c.String(),
                        tare5astlam = c.String(),
                        modelElmtb5 = c.String(),
                        meterPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        metersNumber = c.Int(nullable: false),
                        totalmetermatb5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        modelelmfslat = c.String(),
                        mfslatPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        modelMgary = c.String(),
                        mgaryPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dolfColor = c.Int(nullable: false),
                        da5ly = c.String(),
                        m2bd = c.Int(nullable: false),
                        totalAccessories = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ArkamM2bd",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Arkam = c.Int(nullable: false),
                        Nha2Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nha2y", t => t.Nha2Id, cascadeDelete: true)
                .Index(t => t.Nha2Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Categories_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Categories_ID)
                .Index(t => t.Categories_ID);
            
            CreateTable(
                "dbo.dolfColors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Color = c.Int(nullable: false),
                        Product_ID = c.Int(),
                        Product_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .ForeignKey("dbo.Products", t => t.Product_ID1)
                .Index(t => t.Product_ID)
                .Index(t => t.Product_ID1);
            
            CreateTable(
                "dbo.rf3m2asat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        tare5Eltlb = c.String(),
                        m3adElrf3 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.dolfColors", "Product_ID1", "dbo.Products");
            DropForeignKey("dbo.dolfColors", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Products", "Categories_ID", "dbo.Categories");
            DropForeignKey("dbo.Accesories", "Nha2Id", "dbo.Nha2y");
            DropForeignKey("dbo.ArkamM2bd", "Nha2Id", "dbo.Nha2y");
            DropForeignKey("dbo.abtda2yAcces", "Abtda2YId", "dbo.abtda2y");
            DropForeignKey("dbo.abtda2yArkam", "Abtda2YId", "dbo.abtda2y");
            DropIndex("dbo.dolfColors", new[] { "Product_ID1" });
            DropIndex("dbo.dolfColors", new[] { "Product_ID" });
            DropIndex("dbo.Products", new[] { "Categories_ID" });
            DropIndex("dbo.ArkamM2bd", new[] { "Nha2Id" });
            DropIndex("dbo.Accesories", new[] { "Nha2Id" });
            DropIndex("dbo.abtda2yAcces", new[] { "Abtda2YId" });
            DropIndex("dbo.abtda2yArkam", new[] { "Abtda2YId" });
            DropTable("dbo.rf3m2asat");
            DropTable("dbo.dolfColors");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.ArkamM2bd");
            DropTable("dbo.Nha2y");
            DropTable("dbo.Accesories");
            DropTable("dbo.abtda2yAcces");
            DropTable("dbo.abtda2yArkam");
            DropTable("dbo.abtda2y");
        }
    }
}
