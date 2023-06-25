namespace MikhunaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ingredientes
    {
        [Key]
        public int IngredienteID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Unidad { get; set; }

        public int RecetaID { get; set; }
        [ForeignKey("RecetaID")]
        public Recetas Recetas { get; set; }
    }
}
