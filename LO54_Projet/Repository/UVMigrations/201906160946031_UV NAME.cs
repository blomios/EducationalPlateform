namespace LO54_Projet.Repository.UVMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UVNAME : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UVs", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UVs", "Name");
        }
    }
}
