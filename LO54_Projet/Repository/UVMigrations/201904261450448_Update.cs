namespace LO54_Projet.Repository.UVMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UVs", "Denomination", c => c.String(nullable: false, maxLength: 4));
            CreateIndex("dbo.UVs", "Denomination", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.UVs", new[] { "Denomination" });
            AlterColumn("dbo.UVs", "Denomination", c => c.String(nullable: false));
        }
    }
}
