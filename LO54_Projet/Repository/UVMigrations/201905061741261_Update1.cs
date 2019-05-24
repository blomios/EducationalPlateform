namespace LO54_Projet.Repository.UVMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UVs", "Owner", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UVs", "Owner");
        }
    }
}
