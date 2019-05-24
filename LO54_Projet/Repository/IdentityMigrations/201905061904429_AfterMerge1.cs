namespace LO54_Projet.Repository.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterMerge1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Role");
        }
    }
}
