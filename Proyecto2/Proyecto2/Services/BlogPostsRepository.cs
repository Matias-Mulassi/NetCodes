using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; //Permite usar Lambda

namespace Proyecto2.Services
{
    public class BlogPostsRepository
    {

        //Select de la tabla BlogPost de la DB
        public List<BlogPost> ObtenerTodos()
        {
            using (var db = new BlogContext())
            {
                return db.BlogPosts.Include(x=> x.Comentarios).ToList(); //Incluir Comentarios
            
            }
        
        }

        internal void crear(BlogPost model)
        {
            using (var db = new BlogContext())
            {
                db.BlogPosts.Add(model); 
                db.SaveChanges(); //Guardamos cambios

            }
        }
    }
}