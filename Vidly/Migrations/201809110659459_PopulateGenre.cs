namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) Values('Comedy')");
            Sql("INSERT INTO Genres (Name) Values('Drama')");
            Sql("INSERT INTO Genres (Name) Values('Horror')");
            Sql("INSERT INTO Genres (Name) Values('History')");
        }
        
        public override void Down()
        {
        }
    }
}
