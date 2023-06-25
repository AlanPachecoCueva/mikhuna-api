namespace MikhunaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comentarios
    {
        [Key]
        public int ComentarioID { get; set; }

        public string Contenido { get; set; }

        public int RecetaID { get; set; }

        public int UsuarioID { get; set; }
        [ForeignKey("RecetaID")]
        public Recetas Recetas { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuarios Usuarios { get; set; }
    }
}
