namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,RealeseDate,DateAdded,NumberInStock,GenreId) Values('Shrek','10/10/2010','10/10/2010',1,1)");
            Sql("INSERT INTO Movies (Name,RealeseDate,DateAdded,NumberInStock,GenreId) Values('Anon','10/10/2010','10/10/2010',1,2)");
            Sql("INSERT INTO Movies (Name,RealeseDate,DateAdded,NumberInStock,GenreId) Values('Gladiator','10/8/2010','10/6/2010',1,3)");
        }
        
        public override void Down()
        {
        }
    }
}
