using System.Collections.Generic;
using System.Linq;
using Inventario.Core.Domain;
using Inventario.Core.Domain.Contracts;

namespace Inventario.Aplication
{
    public class CrearProductoCompuestoService
    {
        private IUnitOfWork _UnitOfWork { get; set; }

        public CrearProductoCompuestoService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public CrearProductoCompuestoResponse Ejecutar(CrearProductoCompuestoRequest request)
        {
            var (nombre, precio, ingredientes) = request;
            var producto = new ProductoCompuesto(nombre, precio);
            producto.RegistroIngredientes(ingredientes);
            _UnitOfWork.ProductoRepository.Add(producto);
            _UnitOfWork.Commit();
            return new CrearProductoCompuestoResponse("producto registrado satisfactoriamente");
        }

        public record CrearProductoCompuestoRequest(string nombre, decimal precio, List<Ingrediente> Ingredientes);

        public record CrearProductoCompuestoResponse(string mensaje);
    }
}