namespace LO54_Projet.DataContexts.FileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Uv_IdUv", "dbo.UVs");
            DropIndex("dbo.Files", new[] { "Uv_IdUv" });
            DropIndex("dbo.UVs", new[] { "Denomination" });
            AddColumn("dbo.Files", "idUv", c => c.Int(nullable: false));
            DropColumn("dbo.Files", "Uv_IdUv");
            DropTable("dbo.UVs");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.IdUv);
            
            AddColumn("dbo.Files", "Uv_IdUv", c => c.Int(nullable: false));
            DropColumn("dbo.Files", "idUv");
            CreateIndex("dbo.UVs", "Denomination", unique: true);
            CreateIndex("dbo.Files", "Uv_IdUv");
            AddForeignKey("dbo.Files", "Uv_IdUv", "dbo.UVs", "IdUv", cascadeDelete: true);
        }
    }
}
