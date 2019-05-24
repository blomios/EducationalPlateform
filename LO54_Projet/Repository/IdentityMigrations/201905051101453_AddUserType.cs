namespace LO54_Projet.Repository.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Type");
        }
    }
}
