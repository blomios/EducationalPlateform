namespace LO54_Projet.DataContexts.ProjectMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        IdProject = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        OwnerId = c.String(nullable: false),
                        IdUV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProject);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
        }
    }
}
