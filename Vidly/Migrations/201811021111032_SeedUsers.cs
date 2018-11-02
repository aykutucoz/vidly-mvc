namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6e8168bb-f2ed-4da3-ba96-a4c2f4023188', N'admin@vidly.com', 0, N'AEIbt8CScf30ce/ZEL+rbo6M8QZ9VQ63+itH2vMz+Vpzy/wyAuGC2FQXiMp+GHfQnw==', N'c39ccad1-1994-4183-b9ea-36d8bde92a3e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6ec28fbd-cc67-4be1-98e6-3fde9a80fcb4', N'aykutucoz@yahoo.com', 0, N'AAHO65avai/4fwjsQMStq2EO40E+y0VJMBtm1zQ7/kRbbEBVfWahx/aDu72qem8wBA==', N'55494307-cf48-454d-970c-07cf2d10ba12', NULL, 0, 0, NULL, 1, 0, N'aykutucoz@yahoo.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'44ddf028-cf9b-4ce1-a74a-e183ec974d39', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6e8168bb-f2ed-4da3-ba96-a4c2f4023188', N'44ddf028-cf9b-4ce1-a74a-e183ec974d39')
                    ");
        }
        
        public override void Down()
        {

        }
    }
}
