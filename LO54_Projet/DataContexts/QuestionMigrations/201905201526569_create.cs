namespace LO54_Projet.DataContexts.QuestionMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Questions",
               c => new
               {
                   IdQuestion = c.Int(nullable: false, identity: true),
                   Enonce = c.String(nullable: false),
                   Type = c.String(nullable: false),
                   IdAnswer = c.Int(nullable: false),
                   IdQuizz = c.Int(nullable: false),
               })
               .PrimaryKey(t => t.IdQuestion)
               .ForeignKey("dbo.Quizzs",t=>t.IdQuizz,cascadeDelete:true)
               .Index(t=>t.IdQuizz);
        }
        
        public override void Down()
        {
            DropTable("dbo.Questions");
        }
    }
}
