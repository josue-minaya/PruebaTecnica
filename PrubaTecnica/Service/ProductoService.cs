using AutoMapper;
using PrubaTecnica.DTOs;
using PrubaTecnica.Models;
using PrubaTecnica.Repository;

namespace PrubaTecnica.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public IEnumerable<Producto> GetAll()
        {
            return _productoRepository.GetAll();
        }

        public void Add(ProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO);
            _productoRepository.Add(producto);
            _productoRepository.Save();
        }

        public void Update(Producto producto)
        {
           _productoRepository.Update(producto);
            _productoRepository.Save();
        }

        public void Delete(int id)
        {
            _productoRepository.Delete(id);
            _productoRepository.Save();
        }

        public Producto GetProducto(int id)
        {
          return _productoRepository.GetId(id);
        }
    }
}
