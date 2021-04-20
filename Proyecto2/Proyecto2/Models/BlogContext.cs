using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto2.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext() 
            :base("DefaultConnection")
        {
        
        }

        public DbSet<BlogPost> BlogPosts { get; set; } //Indicamos modelo y nombre de la tabla

        public DbSet<Comentario> Comentarios { get; set; }
    }
}