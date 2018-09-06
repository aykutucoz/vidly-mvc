namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,Genre,RealeseDate,DateAdded,NumberInStock) Values('Shrek','comedy','10/10/2010','10/10/2010',1)");
            Sql("INSERT INTO Movies (Name,Genre,RealeseDate,DateAdded,NumberInStock) Values('Hangover','comedy','10/10/2010','10/10/2010' ,2)");
            Sql("INSERT INTO Movies (Name,Genre,RealeseDate,DateAdded,NumberInStock) Values('Pulp Fiction','Drama','10/10/2010','10/10/2010',3)");
            Sql("INSERT INTO Movies (Name,Genre,RealeseDate,DateAdded,NumberInStock) Values('Gladiator','History','10/10/2010','10/10/2010',4)");
        }
        
        public override void Down()
        {
        }
    }
}
