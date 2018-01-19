namespace Lab2_AngryBirds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMaxLength : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "Player_Player_Name", "dbo.Players");
            DropIndex("dbo.Scores", new[] { "Player_Player_Name" });
            DropPrimaryKey("dbo.Players");
            AlterColumn("dbo.Scores", "Player_Player_Name", c => c.String(maxLength: 25));
            AlterColumn("dbo.Players", "Player_Name", c => c.String(nullable: false, maxLength: 25));
            AddPrimaryKey("dbo.Players", "Player_Name");
            CreateIndex("dbo.Scores", "Player_Player_Name");
            AddForeignKey("dbo.Scores", "Player_Player_Name", "dbo.Players", "Player_Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Player_Player_Name", "dbo.Players");
            DropIndex("dbo.Scores", new[] { "Player_Player_Name" });
            DropPrimaryKey("dbo.Players");
            AlterColumn("dbo.Players", "Player_Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Scores", "Player_Player_Name", c => c.String(maxLength: 30));
            AddPrimaryKey("dbo.Players", "Player_Name");
            CreateIndex("dbo.Scores", "Player_Player_Name");
            AddForeignKey("dbo.Scores", "Player_Player_Name", "dbo.Players", "Player_Name");
        }
    }
}
