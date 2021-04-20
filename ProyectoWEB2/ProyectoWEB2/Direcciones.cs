namespace ProyectoWEB2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Direcciones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Calle { get; set; }

        [Required]
        [StringLength(11)]
        public string Cedula { get; set; }

        public virtual Personas Personas { get; set; }
    }
}
