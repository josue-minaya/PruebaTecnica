using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PrubaTecnica.Models
{

    public partial class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = null!;

        [Precision(18, 2)]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre 0.01 y 999999.99")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser igual o mayor a 0")]
        public int Cantidad { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string Descripcion { get; set; } = string.Empty;
    }
}