using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Inventario.Core.Domain.Test
{
    public class Compuesto_Test
    {
        /*
           Escenario: Retirar cantidad igual a cero 
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Criterio de Aceptación:
           La cantidad de la salida de debe ser mayor a 0
           
           Ejemplo
           Dado El cliente crea un producto compuesto
           Código 10001, Nombre “perro sencillo”, precio 5000, costo debe ser 3000 calculado,
           
           ingredientes:
           1 salchicha
           1 lamino de queso
           1 pan perro
           
           Cuando Va a retirar 0 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. "la cantidad a retirar debe ser mayor a cero"
       */

        [Test]
        public void ExtractCeroProductCompoundFailTest()
        {
            
            //Preparar
            var response = "correcto";
            var perro = new ProductoCompuesto( "perro sencillo", 5000);
            
            var salchicha = new ProductoSimple( "salchicha", 1000, 1000);
            var laminaQueso = new ProductoSimple("lamina de queso", 1000, 1000);
            var panPerro = new ProductoSimple("pan perro", 1000, 1000);
            
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            var ingrediente1 = new Ingrediente();
            ingrediente1.Producto = salchicha;
            ingrediente1.Cantidad = 1;
            
            var ingrediente2 = new Ingrediente();
            ingrediente2.Producto = laminaQueso;
            ingrediente2.Cantidad = 1;
            
            var ingrediente3 = new Ingrediente();
            ingrediente3.Producto = panPerro;
            ingrediente3.Cantidad = 1;
            
            ingredientes.Add(ingrediente1);
            ingredientes.Add(ingrediente2);
            ingredientes.Add(ingrediente3);

            perro.RegistroIngredientes(ingredientes);
            
            //Accion y Verificación
            Assert.Throws<Exception>(()=>perro.Retirar(0));
        }
        
        /*
           Escenario: Retirar cantidad igual A 1
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Criterio de Aceptación:
           En caso de un producto compuesto la cantidad de la salida se le disminuirá a la cantidad existente de cada uno de su ingrediente
           
           Ejemplo
           Dado El cliente crea un producto compuesto
           Código 10001, Nombre “perro sencillo”, precio 5000, costo debe ser 3000 calculado,
           
           ingredientes:
           1 salchicha
           1 lamino de queso
           1 pan perro
           
           Cuando Va a retirar 1 cantidad de perro sencillo  

           Entonces El sistema presentará el mensaje. "Se realizó el retiro de 1 producto(s) de tipo compuesto perro sencillo con un costo de 3000 y un precio de 5000"
       */

        [Test]
        public void ExtractOneProductCompoundSuccesTest()
        {
           
            //Preparar
            var response = true;
            var perro = new ProductoCompuesto( "perro sencillo", 5000);
            
            var salchicha = new ProductoSimple( "salchicha", 1000, 1000);
            var laminaQueso = new ProductoSimple("lamina de queso", 1000, 1000);
            var panPerro = new ProductoSimple("pan perro", 1000, 1000);
            
            salchicha.Registrar(2);
            laminaQueso.Registrar(2);
            panPerro.Registrar( 2);
            
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            var ingrediente1 = new Ingrediente();
            ingrediente1.Producto = salchicha;
            ingrediente1.Cantidad = 1;
            
            var ingrediente2 = new Ingrediente();
            ingrediente2.Producto = laminaQueso;
            ingrediente2.Cantidad = 1;
            
            var ingrediente3 = new Ingrediente();
            ingrediente3.Producto = panPerro;
            ingrediente3.Cantidad = 1;
            
            ingredientes.Add(ingrediente1);
            ingredientes.Add(ingrediente2);
            ingredientes.Add(ingrediente3);

            perro.RegistroIngredientes(ingredientes);

            //accion
            perro.Retirar(1);
            
            //Verificación
            Assert.AreEqual(1, salchicha.Cantidad);
            Assert.AreEqual(1, laminaQueso.Cantidad);
            Assert.AreEqual(1, panPerro.Cantidad);

        }
    }
}