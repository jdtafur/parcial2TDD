using System;
using NUnit.Framework;

namespace Inventario.Core.Domain.Test
{
    public class Simple_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        
        /*
           Escenario: registrar cantidad igual a cero 
           H1: COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 

           Criterio de Aceptación:
           La cantidad de la entrada de debe ser mayor a 0

           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente

           Cuando Va a registrar 0 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. “la cantidad a registrar debe ser mayor a 0 y usted intentó registrar 0 unidades”
       */

        [Test]
        public void RegisterProductSimpleFailTest()
        {
            
            //Preparar
            var response = "correcto";
            var salchicha = new ProductoSimple("salchicha", 1000, 1000);
            
            //accion y Verificación
            Assert.Throws<Exception>(()=>salchicha.Registrar(0)); 
        }
        
        /*
           Escenario: registrar cantidad diferente a cero 
           H1: COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 

           Criterio de Aceptación:
           La cantidad de la entrada de debe ser mayor a 0

           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente

           Cuando Va a registrar 10 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. “Producto agregado, ahora hay 10 unidad(es) del producto salchicha en inventario”
       */

        [Test]
        public void RegisterProductSimpleSuccesTest()
        {
            //Preparar
            var salchicha = new ProductoSimple("salchicha", 1000, 1000);
            
            //Acción
            salchicha.Registrar(10);
            
            //Verificación
            Assert.AreEqual(10, salchicha.Cantidad);
        }
        
        /*
           Escenario: Retirar cantidad igual a cero 
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Criterio de Aceptación:
           La cantidad de la salida de debe ser mayor a 0
           
           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente
           registra 10 cantidad del producto 
           
           Cuando Va a retirar 0 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. "la cantidad a retirar debe ser mayor a 0 y usted intentó retirar 0 unidades"
       */

        [Test]
        public void ExtractCeroProductSimpleFailTest()
        {
            //preparar
            var response = "correcto";
            var salchicha = new ProductoSimple( "salchicha", 1000, 1000);
            salchicha.Registrar(10);
            
            //accion y Verificación
            Assert.Throws<Exception>(()=>salchicha.Retirar(0));
       }
        
        /*
           Escenario: Retirar cantidad mayor a la cantidad en inventario
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente
           registra 10 cantidad del producto 
           
           Cuando Va a retirar 15 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. “lo sentimos, solo hay 10 unidades disponibles en inventario”
       */

        [Test]
        public void ExtractBigProductSimpleFailTest()
        {
            //preparar
            var response = "correcto";
            var salchicha = new ProductoSimple( "salchicha", 1000, 1000);
            salchicha.Registrar(10);

            //Accion y Verificación
            Assert.Throws<Exception>(()=>salchicha.Retirar(15));
        }
        
        /*
           Escenario: Retirar cantidad correcta en inventario
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Criterio de Aceptación:
           En caso de un producto sencillo la cantidad de la salida se le disminuirá a la cantidad existente del producto.

           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente
           registra 20 cantidad del producto 
           
           Cuando Va a retirar 5 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. “Cantidad de producto actualizado, ahora hay 15 unidades del producto salchicha en inventario"
       */

        [Test]
        public void ExtractProductSimpleSuccesTest()
        {
     
            //preparar
            var salchicha = new ProductoSimple( "salchicha", 1000, 1000);
            salchicha.Registrar(20);
            
            //accion
            salchicha.Retirar(5);
            
            //Verificación
            Assert.AreEqual(15, salchicha.Cantidad);
        }
        
    }
}