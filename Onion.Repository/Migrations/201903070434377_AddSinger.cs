namespace Onion.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSinger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Singers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SingerName = c.String(nullable: false, maxLength: 100),
                        SingerImage = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Singers");
        }
    }
}
