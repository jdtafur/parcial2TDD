using Inventario.Core.Domain;
using Inventario.Infrastructure.Data;
using Inventario.Infrastructure.Data.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Inventario.Aplication.Test
{
    public class RegistrarEntradaDeProductoInMemoryTest
    {
        private ProductoContext _dbContext;
        private RegistrarEntradaDeProductoService _service;
        
        //se ejecuta una vez por cada prueba //hace parte del Arrange
        [SetUp]
        public void Setup()
        {
            //Arrange
            var optionsSqlite = new DbContextOptionsBuilder<ProductoContext>()
                .UseInMemoryDatabase(@"ProductosInmemory")
                .Options;

            _dbContext = new ProductoContext(optionsSqlite);

            _service = new RegistrarEntradaDeProductoService(new UnitOfWork(_dbContext));
        }

        [Test]
        public void RegistrarTest()
        {
            //Arrange
            var producto = new ProductoSimple("Pan", 5000, 3000);
            _dbContext.Productos.Add(producto);
            _dbContext.SaveChanges();
            
            //Act
            var request = new RegistrarEntradaDeProductoRequest(1, 5);
            var response = _service.Ejecutar(request);
            
            //Assert
            Assert.AreEqual("", response.mensaje);
            
            //Revert
            _dbContext.Productos.Remove(producto);
            _dbContext.SaveChanges();
        }
    }
}