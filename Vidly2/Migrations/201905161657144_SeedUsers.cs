namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'403d8f25-4f7b-46ae-9bdb-d64f01ae8061', N'guest@vidly.com', 0, N'ACigM+6REq/B0dq8E5qLXRAaHDRtlQrOrLoVVD4cgwW34WFYJut7tzFElOiqkNEJGA==', N'c17fb0a2-2e83-4816-bc53-24a0d97fe7ee', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a57fa891-e786-4f1c-8486-9c164dafedd0', N'admin@vidly.com', 0, N'AIJG/LIws2/NuNDdP05JCtFvQ9Vf031AvRsYv/P1m60VAq5Yy2xKZrjdiaSPa6/bsQ==', N'481aa54e-c766-42b3-84c9-4efed2d19332', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd670ecbf-036e-44d0-8b6d-a4234d5688cb', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a57fa891-e786-4f1c-8486-9c164dafedd0', N'd670ecbf-036e-44d0-8b6d-a4234d5688cb')
");
        }
        
        public override void Down()
        {
        }
    }
}
