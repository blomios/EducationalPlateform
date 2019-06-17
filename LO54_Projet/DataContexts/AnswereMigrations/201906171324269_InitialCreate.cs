namespace LO54_Projet.DataContexts.AnswereMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        IdAnswere = c.Int(nullable: false, identity: true),
                        questionRelated = c.Int(nullable: false),
                        answere = c.String(),
                        isGoodAnswere = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAnswere);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Answers");
        }
    }
}
