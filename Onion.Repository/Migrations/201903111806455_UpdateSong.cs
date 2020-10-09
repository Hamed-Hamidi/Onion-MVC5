namespace Onion.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "SongImageName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Songs", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "CreateDate");
            DropColumn("dbo.Songs", "SongImageName");
        }
    }
}
