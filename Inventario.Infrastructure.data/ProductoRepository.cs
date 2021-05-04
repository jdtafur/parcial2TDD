using Inventario.Core.Domain;
using Inventario.Core.Domain.Contracts;
using Inventario.Infrastructure.Data.Base;

namespace Inventario.Infrastructure.Data
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(IDbContext context) : base(context)
        {
        }
    }
}