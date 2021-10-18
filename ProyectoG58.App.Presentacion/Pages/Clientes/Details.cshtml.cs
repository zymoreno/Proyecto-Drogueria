using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;

namespace ProyectoG58.App.Presentacion
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioClientes repositorioClientes;
        public Cliente cliente { get; set; }

        public DetailsModel()
        {
            this.repositorioClientes=new RepositorioClientes(new ProyectoG58.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int clienteId)
        {
            cliente = repositorioClientes.GetCliente(clienteId);
            if(cliente==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
