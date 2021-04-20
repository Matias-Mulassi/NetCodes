using ProyectoWEB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWEB2.ViewModels
{
    public class IndexViewModel: BaseModelo
    {
        public List<Personas> Personas { get; set; }
    }
}