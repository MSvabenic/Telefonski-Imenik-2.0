namespace TelefonskiImenik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopunaBrojeviTip : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BrojTip (Naziv) VALUES ('Kuæni')");
            Sql("INSERT INTO BrojTip (Naziv) VALUES ('Mobitel')");
            Sql("INSERT INTO BrojTip (Naziv) VALUES ('Posao')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM BrojTip WHERE Id IN (1,2,3)");
        }
    }
}
