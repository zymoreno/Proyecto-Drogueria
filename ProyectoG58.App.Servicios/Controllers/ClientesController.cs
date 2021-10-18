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
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IRepositorioClientes repositorioClientes;

        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
             this.repositorioClientes=new RepositorioClientes(new ProyectoG58.App.Persistencia.AppContext());
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var rng = new Random();

            return repositorioClientes.GetAllClientes(null);

            /*return Enumerable.Range(1, 5).Select(index => new Clientes
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
        }

        
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            

            return repositorioClientes.GetCliente(id);

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