namespace TelefonskiImenik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablicaOsoba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Osoba",
                c => new
                    {
                        Osoba_Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        Grad = c.String(),
                        Opis = c.String(maxLength: 255),
                        Slika = c.Binary(),
                    })
                .PrimaryKey(t => t.Osoba_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Osoba");
        }
    }
}
