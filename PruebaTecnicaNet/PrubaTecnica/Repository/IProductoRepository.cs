using PrubaTecnica.Models;

namespace PrubaTecnica.Repository
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetAll();
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);
        Producto GetId(int id);
        void Save();
    }
}
