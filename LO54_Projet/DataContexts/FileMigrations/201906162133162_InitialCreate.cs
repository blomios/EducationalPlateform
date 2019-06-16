namespace LO54_Projet.DataContexts.FileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        IdFile = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FilePath = c.String(nullable: false),
                        fileType = c.Int(nullable: false),
                        idUv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFile);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Files");
        }
    }
}
