using Inventario.Core.Domain;
using Inventario.Core.Domain.Contracts;

namespace Inventario.Aplication
{
    public class RegistrarEntradaDeProductoService
    {
        private IUnitOfWork _UnitOfWork { get; set; }

        public RegistrarEntradaDeProductoService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public RegistrarEntradaDeProductoResponse Ejecutar(RegistrarEntradaDeProductoRequest request)
        {
            var (productoId, cantidad) = request;
            var producto = (ProductoSimple) _UnitOfWork.ProductoRepository.Find(productoId);
            if (producto == null)
                return new RegistrarEntradaDeProductoResponse("Este producto no se encuentra registrado");

            producto.Registrar(cantidad);
            _UnitOfWork.ProductoRepository.Update(producto);
            _UnitOfWork.Commit();
            return new RegistrarEntradaDeProductoResponse("producto actualizado satisfactoriamente");
        }
    }
    public record RegistrarEntradaDeProductoRequest(int productoId, int cantidad);

    public record RegistrarEntradaDeProductoResponse(string mensaje);
}