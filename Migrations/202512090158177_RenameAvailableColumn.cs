namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAvailableColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailabe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NumberAvailabe", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
