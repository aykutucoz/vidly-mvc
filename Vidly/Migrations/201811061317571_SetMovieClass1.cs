namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMovieClass1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "Movies_Id", newName: "Movie_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_Movies_Id", newName: "IX_Movie_Id");
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
            RenameIndex(table: "dbo.Rentals", name: "IX_Movie_Id", newName: "IX_Movies_Id");
            RenameColumn(table: "dbo.Rentals", name: "Movie_Id", newName: "Movies_Id");
        }
    }
}
