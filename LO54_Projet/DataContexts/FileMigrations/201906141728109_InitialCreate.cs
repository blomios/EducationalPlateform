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
                        Uv_IdUv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFile)
                .ForeignKey("dbo.UVs", t => t.Uv_IdUv, cascadeDelete: true)
                .Index(t => t.Uv_IdUv);
            
            CreateTable(
                "dbo.UVs",
                c => new
                    {
                        IdUv = c.Int(nullable: false, identity: true),
                        Denomination = c.String(nullable: false, maxLength: 4),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Owner = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdUv)
                .Index(t => t.Denomination, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "Uv_IdUv", "dbo.UVs");
            DropIndex("dbo.UVs", new[] { "Denomination" });
            DropIndex("dbo.Files", new[] { "Uv_IdUv" });
            DropTable("dbo.UVs");
            DropTable("dbo.Files");
        }
    }
}
