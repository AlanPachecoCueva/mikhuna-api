namespace MikhunaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Recetas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recetas()
        {
            Calificacions = new HashSet<Calificacions>();
            Comentarios = new HashSet<Comentarios>();
            Favoritos = new HashSet<Favoritos>();
            Ingredientes = new HashSet<Ingredientes>();
            Pasos = new HashSet<Pasos>();
            RecetasTerminadas = new HashSet<RecetasTerminadas>();
        }

        [Key]
        public int RecetaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public float Duracion { get; set; }

        [StringLength(400)]
        public string UrlImagen { get; set; }

        public float CalificacionPromedio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Calificacions> Calificacions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Comentarios> Comentarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Favoritos> Favoritos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Ingredientes> Ingredientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Pasos> Pasos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RecetasTerminadas> RecetasTerminadas { get; set; }
    }
}
