namespace LO54_Projet.DataContexts.AnswereMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answeres",
                c => new
                    {
                        IdAnswere = c.Int(nullable: false, identity: true),
                        answere = c.String(),
                    })
                .PrimaryKey(t => t.IdAnswere);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Answeres");
        }
    }
}
