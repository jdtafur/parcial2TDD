using System;

namespace Inventario.Core.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IProductoRepository ProductoRepository { get; }
        void Commit();
    }
}