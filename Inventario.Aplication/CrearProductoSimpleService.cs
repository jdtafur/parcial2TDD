using Inventario.Core.Domain;
using Inventario.Core.Domain.Contracts;

namespace Inventario.Aplication
{
    public class CrearProductoSimpleService
    {
        private IUnitOfWork _UnitOfWork { get; set; }

        public CrearProductoSimpleService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public CrearProductoSimpleResponse Ejecutar(CrearProductoSimpleRequest request)
        {
            var (nombre, precio, costo) = request;
            var producto = new ProductoSimple(nombre, precio, costo);
            _UnitOfWork.ProductoRepository.Add(producto);
            _UnitOfWork.Commit();
            return new CrearProductoSimpleResponse("producto registrado satisfactoriamente");
        }

        public record CrearProductoSimpleRequest(string nombre, decimal precio, decimal costo);

        public record CrearProductoSimpleResponse(string mensaje);
    }
}