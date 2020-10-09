namespace Onion.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSong : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SingerId = c.Int(nullable: false),
                        SongName = c.String(nullable: false, maxLength: 100),
                        SongFileName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 2000),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Singers", t => t.SingerId, cascadeDelete: true)
                .Index(t => t.SingerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "SingerId", "dbo.Singers");
            DropIndex("dbo.Songs", new[] { "SingerId" });
            DropTable("dbo.Songs");
        }
    }
}
