namespace MikhunaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Favoritos
    {
        public int FavoritosID { get; set; }
        public int Calificacion { get; set; }

        public int RecetaID { get; set; }

        public int UsuarioID { get; set; }
        [ForeignKey("RecetaID")]
        public Recetas Recetas { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuarios Usuarios { get; set; }
    }
}
