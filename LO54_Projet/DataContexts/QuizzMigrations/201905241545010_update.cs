namespace LO54_Projet.DataContexts.QuizzMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quizzs",
                c => new
                {
                        IdQuizz = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LinkedUV_IdUv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdQuizz)
                .ForeignKey("dbo.UVs", t => t.LinkedUV_IdUv, cascadeDelete: true)
                .Index(t => t.LinkedUV_IdUv);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizzs", "LinkedUV_IdUv", "dbo.UVs");
            DropIndex("dbo.Quizzs", new[] { "LinkedUV_IdUv" });
            DropTable("dbo.Quizzs");
        }
    }
}
