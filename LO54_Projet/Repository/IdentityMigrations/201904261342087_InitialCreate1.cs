namespace LO54_Projet.Repository.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nom", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Prenom", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Prenom");
            DropColumn("dbo.AspNetUsers", "Nom");
        }
    }
}
