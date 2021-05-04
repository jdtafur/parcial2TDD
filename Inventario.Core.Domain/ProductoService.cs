using System.Collections.Generic;
using System.Linq;

namespace Inventario.Core.Domain
{
    public class ProductoService
    {
        public decimal CalcularCostoCompuesto(IEnumerable<Ingrediente> ingredientes)
        {
            return ingredientes.Sum(ingrediente => ingrediente.CalcularCosto());
        }
    }
}