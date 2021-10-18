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
    public class ListUserModel : PageModel
    {
        private readonly IRepositorioEmpleados repositorioEmpleados;

        public IEnumerable<Empleado> empleados {get;set;}

        public string searchString; 
       
        public ListUserModel(){
            /*clientes = new List<Cliente>()
            {
                new Cliente{id=1, nombre="Pepito Perez", identificacion=123456, direccion="Cll 5 N 2-4", telefono="3212522125", email="dsfsdf@gmail.com", estado="A"}
                new Cliente = IRepositorioClientes.GetAllClientes();

            };*/

            this.repositorioEmpleados=new RepositorioEmpleados(new ProyectoG58.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            empleados =repositorioEmpleados.GetAllEmpleados(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            empleados = repositorioEmpleados.GetAllEmpleados(searchString);
            return Page();
        }
    }
}
