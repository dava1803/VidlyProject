using System.Data.Entity.Migrations;

namespace VidlyProject.Migrations
{
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SignUpFee = c.Short(nullable: false),
                    DurationInMonths = c.Byte(nullable: false),
                    DiscountRate = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_Id", c => c.Int());
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }

        public override void Down()
        {
            // Cek kolom dulu sebelum hapus (biar gak error)
            Sql(@"IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = N'FK_dbo.Customers_dbo.MembershipTypes_MembershipType_Id')
                  ALTER TABLE dbo.Customers DROP CONSTRAINT FK_dbo.Customers_dbo.MembershipTypes_MembershipType_Id");

            Sql(@"IF EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_MembershipType_Id')
                  DROP INDEX IX_MembershipType_Id ON dbo.Customers");

            Sql(@"IF EXISTS (SELECT * FROM sys.columns WHERE Name = N'MembershipType_Id' AND Object_ID = Object_ID(N'dbo.Customers'))
                  ALTER TABLE dbo.Customers DROP COLUMN MembershipType_Id");

            Sql(@"IF EXISTS (SELECT * FROM sys.columns WHERE Name = N'MembershipTypeId' AND Object_ID = Object_ID(N'dbo.Customers'))
                  ALTER TABLE dbo.Customers DROP COLUMN MembershipTypeId");

            Sql(@"IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.MembershipTypes') AND type = N'U')
                  DROP TABLE dbo.MembershipTypes");
        }
    }
}
