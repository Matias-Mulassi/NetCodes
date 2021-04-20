namespace ProyectoWEB2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creando_SP1 : DbMigration
    {
        public override void Up()
        {
            //Crear procedimiento para filtrar personas por edad
            CreateStoredProcedure("sp_Personas_Por_Edad",x=> new { Edad =x.Int()} ,
                @"SELECT Nombre, Edad FROM Personas
                    WHERE Edad= @Edad");

            //Crear procedimiento con valor por defecto
            CreateStoredProcedure("sp_Personas_Mayores_De_Edad", x => new { Edad = x.Int(18) },
                @"SELECT Nombre, Edad FROM Personas
                    WHERE Edad>= @Edad");

            //Invocamos storeProcedures que tenemos guardados en archivos Recursos
            //Usamos funcion SQL Para ejecutar una query. Traemos los recursos de SQL.
            Sql(RecursosSQL.Crear_sp_Borra_Personas_Menores); //Esta es la funcion mas preferida
        }
        
        public override void Down()
        {
            DropStoredProcedure("sp_Personas_Por_Edad");
            DropStoredProcedure("sp_Personas_Mayores_De_Edad");
            Sql(RecursosSQL.Borra_sp_Borrar_Personas_Menores);
        }
    }
}
