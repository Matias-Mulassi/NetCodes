namespace ProyectoWEB2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creando_SP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Calle = c.String(nullable: false, maxLength: 120),
                        Cedula = c.String(nullable: false, maxLength: 11, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Cedula)
                .Index(t => t.Cedula);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Cedula = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cedula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direcciones", "Cedula", "dbo.Personas");
            DropIndex("dbo.Direcciones", new[] { "Cedula" });
            DropTable("dbo.Personas");
            DropTable("dbo.Direcciones");
        }
    }
}
