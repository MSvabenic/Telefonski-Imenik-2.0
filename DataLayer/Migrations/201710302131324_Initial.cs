namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BrojeviOsoba", "Broj", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BrojeviOsoba", "Broj", c => c.Int(nullable: false));
        }
    }
}
