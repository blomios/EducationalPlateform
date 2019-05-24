namespace LO54_Projet.Repository.UVMigrations
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
                        Denomination = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdUv);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UVs");
        }
    }
}
