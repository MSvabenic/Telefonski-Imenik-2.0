namespace TelefonskiImenik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablicaTipBroja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrojTip",
                c => new
                    {
                        BrojTipId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.BrojTipId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BrojTip");
        }
    }
}
