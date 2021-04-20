namespace ProyectoWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CuartaMigracion : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Direccions", newName: "Direccion");
            RenameTable(name: "dbo.Personas", newName: "Persona");
            RenameTable(name: "dbo.SubDireccions", newName: "SubDireccion");
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Persona_Curso",
                c => new
                    {
                        PersonaId = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        CursoId = c.Int(nullable: false),
                        Abandonado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonaId, t.CursoId })
                .ForeignKey("dbo.Curso", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Persona2", t => t.PersonaId, cascadeDelete: true)
                .Index(t => t.PersonaId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Persona2",
                c => new
                    {
                        Cedula = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Nombre = c.String(),
                        Nacimiento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Edad = c.Int(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 16, scale: 2),
                        Direccion_CodigoDireccion = c.Int(nullable: false),
                        Direccion_Calle = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Cedula)
                .ForeignKey("dbo.Direcciones", t => new { t.Direccion_CodigoDireccion, t.Direccion_Calle })
                .Index(t => new { t.Direccion_CodigoDireccion, t.Direccion_Calle });
            
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Calle = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Codigo, t.Calle });
            
            CreateTable(
                "dbo.TarjetaDeCredito",
                c => new
                    {
                        PAN = c.String(nullable: false, maxLength: 128),
                        NombreEnTarjeta = c.String(),
                        Persona_Cedula = c.String(nullable: false, maxLength: 11, fixedLength: true),
                    })
                .PrimaryKey(t => t.PAN)
                .ForeignKey("dbo.Persona2", t => t.Persona_Cedula, cascadeDelete: true)
                .Index(t => t.Persona_Cedula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TarjetaDeCredito", "Persona_Cedula", "dbo.Persona2");
            DropForeignKey("dbo.Persona2", new[] { "Direccion_CodigoDireccion", "Direccion_Calle" }, "dbo.Direcciones");
            DropForeignKey("dbo.Persona_Curso", "PersonaId", "dbo.Persona2");
            DropForeignKey("dbo.Persona_Curso", "CursoId", "dbo.Curso");
            DropIndex("dbo.TarjetaDeCredito", new[] { "Persona_Cedula" });
            DropIndex("dbo.Persona2", new[] { "Direccion_CodigoDireccion", "Direccion_Calle" });
            DropIndex("dbo.Persona_Curso", new[] { "CursoId" });
            DropIndex("dbo.Persona_Curso", new[] { "PersonaId" });
            DropTable("dbo.TarjetaDeCredito");
            DropTable("dbo.Direcciones");
            DropTable("dbo.Persona2");
            DropTable("dbo.Persona_Curso");
            DropTable("dbo.Curso");
            RenameTable(name: "dbo.SubDireccion", newName: "SubDireccions");
            RenameTable(name: "dbo.Persona", newName: "Personas");
            RenameTable(name: "dbo.Direccion", newName: "Direccions");
        }
    }
}
