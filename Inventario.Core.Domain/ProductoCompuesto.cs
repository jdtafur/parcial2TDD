using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventario.Core.Domain
{
    public class ProductoCompuesto : Producto
    {
        protected List<Ingrediente> Ingredientes;
        
        public ProductoCompuesto(string nombre, decimal precio) : base(nombre, precio)
        {
            Ingredientes = new List<Ingrediente>();
            Movimientos = new List<Movimiento>();
        }

        public void RegistroIngredientes(List<Ingrediente> ingredientes)
        {
            Ingredientes = ingredientes;
            Costo = CalcularCosto();
        }

        //el costo de los productos compuestos corresponden al costo de sus ingredientes por 
        private decimal CalcularCosto()
        {
            var productoService = new ProductoService();
            return  productoService.CalcularCostoCompuesto(Ingredientes);
        }

        public override void Retirar(int cantidad)
        {

            if (cantidad < 1)
               throw new Exception("la cantidad a retirar debe ser mayor a cero");
            
            if (!ValidarExistenciasDeIngredientes(cantidad))
                throw new Exception("No hay suficientes ingredientes");

            foreach (var ingrediente in Ingredientes)
            {
                ingrediente.Producto.Retirar(ingrediente.Cantidad * cantidad);
            }
        }

        private bool ValidarExistenciasDeIngredientes(int cantidad)
        {
            return Ingredientes.All(ingrediente => ingrediente.Producto.Cantidad - ingrediente.Cantidad * cantidad >= 0);
        }
    }
}