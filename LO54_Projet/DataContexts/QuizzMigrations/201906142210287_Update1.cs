namespace LO54_Projet.DataContexts.QuizzMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "isGoodAnswere");
        }
    }
}
