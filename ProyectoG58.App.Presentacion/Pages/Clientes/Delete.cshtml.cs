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
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioClientes repositorioClientes;

        [BindProperty]
        public Cliente cliente  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public DeleteModel(){
             this.repositorioClientes  =new RepositorioClientes(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int clienteId)
        {
            cliente = repositorioClientes.GetCliente(clienteId);
            if(cliente == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }
        //se ejecuta al presionar Eliminar en el formulario 
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(cliente.id > 0)
            {
                try{
                   repositorioClientes.DeleteCliente(cliente.id);
                    Mensaje = "Registro eliminado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al eliminar el Registro";
                }
               
            }
            return Page();
        }
    }
}
