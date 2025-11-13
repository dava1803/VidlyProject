namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddMembershipTypeToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());

            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Premium' WHERE Id = 4");
        }

        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
