using Banco.Domain.Base;
using Inventario.Core.Domain.Base;

namespace Inventario.Core.Domain
{
    public class Ingrediente : Entity<int>
    {
        public ProductoSimple Producto { get; set; }
        public int Cantidad { get; set; }
        
        public decimal CalcularCosto()
        {
            return Producto.Costo * Cantidad;
        }
    }
}