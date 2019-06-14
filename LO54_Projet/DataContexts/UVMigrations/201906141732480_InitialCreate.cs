namespace LO54_Projet.DataContexts.UVMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.IdUv)
                .Index(t => t.Denomination, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UVs", new[] { "Denomination" });
            DropTable("dbo.UVs");
        }
    }
}
