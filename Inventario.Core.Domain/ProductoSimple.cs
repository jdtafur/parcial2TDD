using System;
using System.Collections.Generic;
using Inventario.Core.Domain.Enums;

namespace Inventario.Core.Domain
{
    public class ProductoSimple : Producto
    {
        //puedo crear un producto, pero al registrarlo en inventario es donde debo hacer la validacion sobre la cantidad
        public ProductoSimple(string nombre, decimal precio, decimal costo) : base(nombre, precio, costo)
        {
            Movimientos = new List<Movimiento>();
        }

        public void Registrar(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new Exception($"la cantidad a registrar debe ser mayor a 0 y usted intentó registrar {cantidad} unidades");
            }

            Cantidad += cantidad;
        }

        public override void Retirar(int cantidad)
        {
            if (cantidad <= 0)
                throw new Exception($"no es posible retirar {cantidad} unidades");
            if (cantidad > Cantidad)
                throw new Exception($"lo sentimos, solo hay {Cantidad} unidades disponibles en inventario");

            Cantidad -= cantidad;
            
            Movimientos.Add(new Movimiento(Costo, Precio, cantidad, TipoMovimiento.Salida));
        }
    }
}