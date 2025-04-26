using PrubaTecnica.Models;

namespace PrubaTecnica.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly PruebaTecnicaContext _context;

        public ProductoRepository(PruebaTecnicaContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> GetAll()
        {
            return _context.PRODUCTO.ToList();
        }

        public void Add(Producto producto)
        {
            _context.PRODUCTO.Add(producto);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Producto producto)
        {
            var existingProducto = _context.PRODUCTO.Find(producto.Id);
           
            if (existingProducto != null) {
                existingProducto.Nombre = producto.Nombre;
                existingProducto.Precio = producto.Precio;
                existingProducto.Cantidad = producto.Cantidad;
                existingProducto.Descripcion = producto.Descripcion;
            }
            
        }

        public void Delete(int id)
        {
            var producto = _context.PRODUCTO.Find(id);
            if (producto != null)
            {
                _context.PRODUCTO.Remove(producto);
            }
            else
            {
                throw new Exception("Producto no encontrado");
            }

        }

        public Producto GetId(int id)
        {
            return _context.PRODUCTO.Find(id);
        }
    }
}