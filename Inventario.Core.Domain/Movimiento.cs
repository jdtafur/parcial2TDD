using System;
using Inventario.Core.Domain.Base;
using Inventario.Core.Domain.Enums;

namespace Inventario.Core.Domain
{
    public class Movimiento : Entity<long>
    {
        public decimal CostoProducto { get; }
        public decimal PrecioVenta { get; }
        public int Cantidad { get; }
        public TipoMovimiento Type { get; }
        public DateTime Fecha { get; set; }

        public Movimiento(decimal costoProducto, decimal precioVenta, int cantidad, TipoMovimiento type)
        {
            Fecha = DateTime.Now;
            CostoProducto = costoProducto;
            PrecioVenta = precioVenta;
            Cantidad = cantidad;
            Type = type;
        }
    }
}