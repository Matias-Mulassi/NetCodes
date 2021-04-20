namespace ProyectoWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TerceraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Personas", "Nombre");
            CreateIndex("dbo.Personas", new[] { "Nacimiento", "Edad" }, name: "Ix_Nacimiento_Edad");
            Sql("CREATE INDEX IX_Edad_Sexo ON dbo.Personas(Edad asc,Sexo desc)");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Personas", "Ix_Nacimiento_Edad");
            DropIndex("dbo.Personas", new[] { "Nombre" });
            Sql("DROP INDEX IX_Edad_Sexo ON dbo.Personas");
        }
    }
}
