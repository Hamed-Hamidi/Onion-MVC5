namespace Onion.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSongLikeAndVisit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SongLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        UserIP = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.SongVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        UserIP = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongVisits", "SongId", "dbo.Songs");
            DropForeignKey("dbo.SongLikes", "SongId", "dbo.Songs");
            DropIndex("dbo.SongVisits", new[] { "SongId" });
            DropIndex("dbo.SongLikes", new[] { "SongId" });
            DropTable("dbo.SongVisits");
            DropTable("dbo.SongLikes");
        }
    }
}
