namespace Proyecto2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Proyecto2.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //se encarga de hacer los cambios en la DB si cambia estructura
            // AutomaticMigrationDataLossAllowed = true; Permitir que se pierda data al cambiar el tamaño de estructura de la db
        }

        protected override void Seed(Proyecto2.Models.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //Agregar Manualmente a la DB una instancia de comentario
            context.Comentarios.AddOrUpdate(x => x.Id, new Models.Comentario()
            {
                Id= 1,
                Autor= "Matias",
                BlogPostId=1,
                Contenido="Ejemplo de contenido"
            });
        }
    }
}
