namespace CSharpWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'59cc633b-64ff-4db6-a73a-f80bb58b3772', N'guest@unyt.edu.al', 0, N'APzFGTCcMqvkC/e7qOE5gYof/JzT4WhYHeZ1vCMTBas/f/PbwoGc/i6Uwl5+vCi4YQ==', N'5372a4e0-3cea-4909-8fe0-198c20db1afc', NULL, 0, 0, NULL, 1, 0, N'guest@unyt.edu.al')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd61ce06d-7cfd-4f37-a6d0-02202ae8c5a3', N'admin@unyt.edu.al', 0, N'AJtJxGctTvUG06bqccxeF/mOIWCkMzDGZWcfDf8P8inNfP0DCQFifrvyHNZBmFK3ow==', N'd56ff9ff-4b4b-46bd-8bdf-3ffbdf290aba', NULL, 0, 0, NULL, 1, 0, N'admin@unyt.edu.al')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f72c1ea4-9021-4e6f-a3de-9ee4234e1cf6', N'CanAddStudents/Professors')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd61ce06d-7cfd-4f37-a6d0-02202ae8c5a3', N'f72c1ea4-9021-4e6f-a3de-9ee4234e1cf6')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
