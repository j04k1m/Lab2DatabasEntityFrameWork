namespace Lab2_AngryBirds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Empty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Map_Name = c.String(nullable: false, maxLength: 30),
                        Birds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Map_Name);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Score_Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        Map_Map_Name = c.String(maxLength: 30),
                        Player_Player_Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Score_Id)
                .ForeignKey("dbo.Maps", t => t.Map_Map_Name)
                .ForeignKey("dbo.Players", t => t.Player_Player_Name)
                .Index(t => t.Map_Map_Name)
                .Index(t => t.Player_Player_Name);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Player_Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Player_Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Player_Player_Name", "dbo.Players");
            DropForeignKey("dbo.Scores", "Map_Map_Name", "dbo.Maps");
            DropIndex("dbo.Scores", new[] { "Player_Player_Name" });
            DropIndex("dbo.Scores", new[] { "Map_Map_Name" });
            DropTable("dbo.Players");
            DropTable("dbo.Scores");
            DropTable("dbo.Maps");
        }
    }
}
