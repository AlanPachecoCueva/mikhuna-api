namespace MikhunaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pasos
    {
        [Key]
        public int PasosID { get; set; }

        [Required]
        [StringLength(100)]
        public string Paso { get; set; }

        public int RecetaID { get; set; }
        [ForeignKey("RecetaID")]
        public Recetas Recetas { get; set; }
    }
}
