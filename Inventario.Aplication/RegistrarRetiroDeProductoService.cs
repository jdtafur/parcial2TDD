using Inventario.Core.Domain.Contracts;

namespace Inventario.Aplication
{
    public class RegistrarRetiroDeProductoService
    {
        private IUnitOfWork _UnitOfWork { get; set; }

        public RegistrarRetiroDeProductoService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public RegistrarSalidaDeProductoResponse Ejecutar(RegistrarSalidaDeProductoRequest request)
        {
            var (productoId, cantidad) = request;
            var producto = _UnitOfWork.ProductoRepository.Find(productoId);
            if (producto == null)
                return new RegistrarSalidaDeProductoResponse("Este producto no se encuentra registrado");

            producto.Retirar(cantidad);
            _UnitOfWork.ProductoRepository.Update(producto);
            _UnitOfWork.Commit();
            return new RegistrarSalidaDeProductoResponse("producto actualizado satisfactoriamente");
        }

        public record RegistrarSalidaDeProductoRequest(int productoId, int cantidad);

        public record RegistrarSalidaDeProductoResponse(string mensaje);
    }
}