namespace TelefonskiImenik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablicaBrojeviOsoba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrojeviOsoba",
                c => new
                    {
                        BrojeviOsobaId = c.Int(nullable: false, identity: true),
                        OsobaId = c.Int(nullable: false),
                        BrojTipId = c.Int(nullable: false),
                        Broj = c.Int(nullable: false),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.BrojeviOsobaId)
                .ForeignKey("dbo.BrojTip", t => t.BrojTipId, cascadeDelete: true)
                .ForeignKey("dbo.Osoba", t => t.OsobaId, cascadeDelete: true)
                .Index(t => t.OsobaId)
                .Index(t => t.BrojTipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BrojeviOsoba", "OsobaId", "dbo.Osoba");
            DropForeignKey("dbo.BrojeviOsoba", "BrojTipId", "dbo.BrojTip");
            DropIndex("dbo.BrojeviOsoba", new[] { "BrojTipId" });
            DropIndex("dbo.BrojeviOsoba", new[] { "OsobaId" });
            DropTable("dbo.BrojeviOsoba");
        }
    }
}
