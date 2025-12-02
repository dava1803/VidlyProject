namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] 
    ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp],
     [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled],
     [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
VALUES 
    (N'09cba2b3-42b5-4544-a8ed-9d1d83adaaeb',
     N'user01@vidly.com', 0,
     N'AI+Be+5myB97QTWjk0TbTvkSo+O3rcfzfSGYFXePU5aNAnRw7UwbFsxpifX3f0zFxw==',
     N'7e9f9898-fe4c-43fa-b54c-68cfe4cf8ca8',
     NULL, 0, 0, NULL, 0, 0, N'user01@vidly.com');

INSERT INTO [dbo].[AspNetUsers] 
    ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp],
     [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled],
     [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
VALUES 
    (N'a92c9052-1c9a-44ea-92b6-bee46d7c712e',
     N'admin01@vidly.com', 0,
     N'ALregaC68VYkyhWhCd4isE6fqrEBC42AA6oMCzdIlx0AsHF+pruR1EffeG3czXu9Cg==',
     N'd288f270-b0a7-4db2-9a27-84755a560e3f',
     NULL, 0, 0, NULL, 0, 0, N'admin01@vidly.com');

INSERT INTO [dbo].[AspNetRoles] 
    ([Id], [Name]) 
VALUES 
    (N'b73dc9cb-2cf4-4719-ae0e-b62b23f517ac',
     N'CanManageMovies');

INSERT INTO [dbo].[AspNetUserRoles] 
    ([UserId], [RoleId]) 
VALUES 
    (N'a92c9052-1c9a-44ea-92b6-bee46d7c712e',  -- admin
     N'b73dc9cb-2cf4-4719-ae0e-b62b23f517ac'); -- role CanManageMovies
");
        }

        public override void Down()
        {
        }
    }
}
