using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoG58.App.Presentacion
{
    //[Authorize]
    public class ListClientModel : PageModel
    {

        private readonly IRepositorioClientes repositorioClientes;

        public IEnumerable<Cliente> clientes {get;set;}

        public string searchString; 
       
        public ListClientModel(){
            /*clientes = new List<Cliente>()
            {
                new Cliente{id=1, nombre="Pepito Perez", identificacion=123456, direccion="Cll 5 N 2-4", telefono="3212522125", email="dsfsdf@gmail.com", estado="A"}
                new Cliente = IRepositorioClientes.GetAllClientes();

            };*/

            this.repositorioClientes=new RepositorioClientes(new ProyectoG58.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            clientes =repositorioClientes.GetAllClientes(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            clientes = repositorioClientes.GetAllClientes(searchString);
            return Page();
        }
    }
}
