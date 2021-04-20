using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ProyectoWEB.Models
{
    public class ApplicationDbContext : DbContext //Manipulamos Querys
    {
        public DbSet<Persona> Persona { get; set; } //Esto va a hacer una tabla en la DB.

        public DbSet<Direccion> Direccion { get; set; }

        public DbSet<SubDireccion> SubDireccion { get; set; }

        public DbSet<TarjetaDeCredito> TarjetaDeCredito{get; set;}

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Persona_Curso> Persona_Curso { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Toda direccion se relaciona con una persona, no siempre una persona tiene dirección
            modelBuilder.Entity<Direccion2>().HasRequired(x => x.Persona).WithOptional(t => t.Direccion);

            //Toda direccion se relaciona con una persona, toda persona tiene una dirección.
            modelBuilder.Entity<Direccion2>().HasRequired(x => x.Persona).WithRequiredPrincipal(x => x.Direccion);

            //Toda tarjeta se relaciona con una persona, no siempre una persona tiene tarjeta.

            modelBuilder.Entity<TarjetaDeCredito>().HasRequired(x => x.Persona);

            /*
            //Todo curso se relaciona con varias personas, toda persona se relacionan con varios cursos.
            //Relacion Muchos a muchos
            modelBuilder.Entity<Curso>().HasMany(x => x.Personas).WithMany(x=> x.Cursos);


            //Personalizamos la relacion Muchos a muchos
            modelBuilder.Entity<Curso>().HasMany(t => t.Personas).WithMany(x => x.Cursos)
                .Map(m=>
                {
                    m.ToTable("Persona_Curso"); //Nombre de la tabla
                    m.MapLeftKey("IdCurso"); //Nombre llave foranea a cursos
                    m.MapRightKey("IdPersona"); //Nombre llave foranea personas
                
                
                });
            */

            modelBuilder.Entity<Persona_Curso>().HasKey(x => new { x.PersonaId, x.CursoId }); //Definimos las claves primarias de las tablas


            //Decimos cual columna es clave primaria
            modelBuilder.Entity<Persona2>().HasKey(x => x.Cedula);

            //Definimos una clave primaria compuesta
            modelBuilder.Entity<Direccion2>().HasKey(x => new { x.CodigoDireccion, x.Calle});

            //El valor de la llave primaria será asignado por nosotros. Es decir, la database no le autogenera un valor, se lo colocamos nosotros.
            modelBuilder.Entity<Direccion2>().Property(x => x.CodigoDireccion).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //El campo cedula de la tabla Persona es de longitud fija y tiene longitud maxima de 11.
            modelBuilder.Entity<Persona2>().Property(x => x.Cedula).IsFixedLength().HasMaxLength(11);

           
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2")); //cada datetime lo configuramos como datetime2

            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Codigo")).Configure(p => p.IsKey()); //Aquí se menciona que si existe una propiedad entera con nombre codigo, se hará primary key

            modelBuilder.Entity<Direccion>().HasRequired(x => x.Persona);
            
            modelBuilder.Entity<SubDireccion>().HasRequired(x => x.Direccion);

            //modelBuilder.Entity<Direccion>().HasRequired(x => x.Persona).WithMany().HasForeignKey(x=>x.IdPersona); //Toda entidad direccion debe tener asignada una persona. Aquí definimos la clave foranea y es IdPersona

            modelBuilder.Entity<Direccion>().Property(x => x.Calle).HasMaxLength(300).IsRequired(); //Definimos longitud maxima y que es requerida
            
           
            //Propiedad no mapeada en en una columna
            modelBuilder.Entity<Persona2>().Ignore(x => x.Resumen);
            //Definir el nombre de una columna
            modelBuilder.Entity<Direccion2>().Property(x => x.CodigoDireccion).HasColumnName("Codigo");

            //Definir el nombre de una tabla
            modelBuilder.Entity<Direccion2>().ToTable("Direcciones");


            //Convenciones

            //No pluralizar nombres de tablas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //No mapear los decimales a numeric(18,2)
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();

            //Convencion: los decimales serán decimales(16,2)

            modelBuilder.Properties<Decimal>().Configure(x => x.HasColumnType("decimal").HasPrecision(16, 2));
           

            base.OnModelCreating(modelBuilder); //Esto es porque se hereda del db context y tiene una funcion especial que se requiere ejecutar
        }

        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry) //Funcion que valida entidades que ingresan datos a la DB
        {

            if (entityEntry.State == EntityState.Deleted)
            {
                return true; //Entidades que se borran no se validan
            }

            return base.ShouldValidateEntity(entityEntry);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry.Entity is Persona & entityEntry.State == EntityState.Deleted)
            {
                var entidad = entityEntry.Entity as Persona;
                if (entidad.Edad < 18)
                {
                    return new DbEntityValidationResult(entityEntry, new DbValidationError[] {
                     new DbValidationError("Edad","No se puede borrar a un menor de edad.")});
                }
            }

            return base.ValidateEntity(entityEntry, items);
        }

        public override int SaveChanges() //Todo cambio que hicimos a clases que se corresponden con clases, se guarden los cambios
        {
            var entidades = ChangeTracker.Entries();
            if (entidades != null)
            {
                foreach (var entidad in entidades.Where(c => c.State != EntityState.Unchanged))
                {
                    Auditar(entidad); //Guardo los cambios por motivos de seguridad
                }
            }
            return base.SaveChanges();
        }
        private void Auditar(DbEntityEntry entidad)
        { 
        
        }

    }
}