namespace LO54_Projet.DataContexts.QuestionMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        IdQuestion = c.Int(nullable: false, identity: true),
                        Enonce = c.String(nullable: false),
                        MyQuizz_IdQuizz = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdQuestion)
                .ForeignKey("dbo.Quizzs", t => t.MyQuizz_IdQuizz, cascadeDelete: true)
                .Index(t => t.MyQuizz_IdQuizz);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        IdQuizz = c.Int(nullable: false, identity: true),
                        LinkedUV_IdUv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdQuizz)
                .ForeignKey("dbo.UVs", t => t.LinkedUV_IdUv, cascadeDelete: true)
                .Index(t => t.LinkedUV_IdUv);
            
            CreateTable(
                "dbo.UVs",
                c => new
                    {
                        IdUv = c.Int(nullable: false, identity: true),
                        Denomination = c.String(nullable: false, maxLength: 4),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Owner = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdUv)
                .Index(t => t.Denomination, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "MyQuizz_IdQuizz", "dbo.Quizzs");
            DropForeignKey("dbo.Quizzs", "LinkedUV_IdUv", "dbo.UVs");
            DropIndex("dbo.UVs", new[] { "Denomination" });
            DropIndex("dbo.Quizzs", new[] { "LinkedUV_IdUv" });
            DropIndex("dbo.Questions", new[] { "MyQuizz_IdQuizz" });
            DropTable("dbo.UVs");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Questions");
        }
    }
}
