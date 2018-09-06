namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDateTimeCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsleter,MembershipTypeId,Birthdate) VALUES('Hasan','True','2','10/04/1980')");
        }
        
        public override void Down()
        {
        }
    }
}
