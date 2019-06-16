namespace LO54_Projet.DataContexts.QuizzMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        IdQuizz = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdUv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdQuizz);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        IdQuestion = c.Int(nullable: false, identity: true),
                        IdQuizz = c.Int(nullable: false),
                        Enonce = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdQuestion)
                .ForeignKey("dbo.Quizzs", t => t.IdQuizz, cascadeDelete: true)
                .Index(t => t.IdQuizz);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        IdAnswere = c.Int(nullable: false, identity: true),
                        questionRelated = c.Int(nullable: false),
                        answere = c.String(),
                        isGoodAnswere = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAnswere)
                .ForeignKey("dbo.Questions", t => t.questionRelated, cascadeDelete: true)
                .Index(t => t.questionRelated);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "questionRelated", "dbo.Questions");
            DropForeignKey("dbo.Questions", "IdQuizz", "dbo.Quizzs");
            DropIndex("dbo.Answers", new[] { "questionRelated" });
            DropIndex("dbo.Questions", new[] { "IdQuizz" });
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.Quizzs");
        }
    }
}
