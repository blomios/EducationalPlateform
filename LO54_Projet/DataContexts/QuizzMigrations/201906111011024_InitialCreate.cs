namespace LO54_Projet.DataContexts.QuizzMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        IdQuizz = c.Int(nullable: false, identity: true),
                        LinkedUV_IdUv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdQuizz)
                .ForeignKey("dbo.UVs", t => t.LinkedUV_IdUv, cascadeDelete: true)
                .Index(t => t.LinkedUV_IdUv);
            
            CreateTable(
                "dbo.UVs",
                c => new
                    {
                        IdUv = c.Int(nullable: false, identity: true),
                        Denomination = c.String(nullable: false, maxLength: 4),
                        Description = c.String(),
                        Owner = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdUv)
                .Index(t => t.Denomination, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizzs", "LinkedUV_IdUv", "dbo.UVs");
            DropIndex("dbo.UVs", new[] { "Denomination" });
            DropIndex("dbo.Quizzs", new[] { "LinkedUV_IdUv" });
            DropTable("dbo.UVs");
            DropTable("dbo.Quizzs");
        }
    }
}
