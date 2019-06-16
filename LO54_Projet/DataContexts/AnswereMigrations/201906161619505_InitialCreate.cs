namespace LO54_Projet.DataContexts.AnswereMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            DropTable("dbo.Answers");
        }
    }
}
