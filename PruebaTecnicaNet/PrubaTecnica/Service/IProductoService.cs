using PrubaTecnica.DTOs;
using PrubaTecnica.Models;

namespace PrubaTecnica.Service
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAll();
        void Add(ProductoDTO productoDTO);
        void Delete(int id);
        void Update(Producto producto);
        Producto GetProducto(int id);
    }
}