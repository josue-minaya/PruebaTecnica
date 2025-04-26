namespace PrubaTecnica.DTOs
{
    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int cantidad { get; set; }
        public string Descripcion { get; set; } = string.Empty;

    }
}
