namespace TelefonskiImenik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OsobaTablicaIzmjenaIDa : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Osoba");
            DropColumn("dbo.Osoba", "Osoba_Id");
            AddColumn("dbo.Osoba", "OsobaId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Osoba", "OsobaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Osoba", "Osoba_Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Osoba");
            DropColumn("dbo.Osoba", "OsobaId");
            AddPrimaryKey("dbo.Osoba", "Osoba_Id");
        }
    }
}
