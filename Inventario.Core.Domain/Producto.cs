using System;
using System.Collections.Generic;
using Inventario.Core.Domain.Base;
using Inventario.Core.Domain.Enums;

namespace Inventario.Core.Domain
{
    public abstract class Producto : Entity<int>, IAggregateRoot
    {
        public string Nombre { get; private set;}
        public decimal Precio { get; protected set; }
        public decimal Costo { get; protected set; }
        public int Cantidad { get; set; }
        
        public List<Movimiento> Movimientos { get; set; }

        protected Producto(string nombre, decimal precio, decimal costo)
        {            
            Nombre = nombre;
            Precio = precio;
            Costo = costo;
            Cantidad = 0;            
        }

        protected Producto(string nombre, decimal precio)
        {            
            Nombre = nombre;
            Precio = precio;            
        }

        protected Producto(string nombre, decimal costo, int cantidad)
        {
            Nombre = nombre;
            Costo = costo;
            Cantidad = cantidad;
        }

        public abstract void Retirar(int cantidad);
    }
}