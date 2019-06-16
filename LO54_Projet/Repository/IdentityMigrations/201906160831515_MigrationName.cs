namespace LO54_Projet.Repository.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UVInscription",
                c => new
                    {
                        IdUv = c.Int(nullable: false, identity: true),
                        Denomination = c.String(nullable: false, maxLength: 4),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Owner = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdUv)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Denomination, unique: true)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UVs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UVs", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UVs", new[] { "Denomination" });
            DropTable("dbo.UVs");
        }
    }
}
