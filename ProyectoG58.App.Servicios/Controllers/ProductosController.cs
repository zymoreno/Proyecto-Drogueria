using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;
using Microsoft.AspNetCore.Cors;

namespace ProyectoG58.App.Servicios.Controllers
{
    
    //[EnableCors("politica")]
    [ApiController]
    [Route("productos")]
    public class ProductosController : ControllerBase
    {
        private readonly IRepositorioProductos repositorioProductos;

        private readonly ILogger<ProductosController> _logger;

        public ProductosController(ILogger<ProductosController> logger)
        {
            _logger = logger;
             this.repositorioProductos=new RepositorioProductos(new ProyectoG58.App.Persistencia.AppContext());
        }

        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            var rng = new Random();

            return repositorioProductos.GetAllProductos(null);

            /*return Enumerable.Range(1, 5).Select(index => new Clientes
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
        }

        
        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            

            return repositorioProductos.GetProducto(id);

            /*return Enumerable.Range(1, 5).Select(index => new Clientes
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
    }
}