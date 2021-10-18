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
    public class EditModel : PageModel
    {
        private readonly IRepositorioClientes repositorioClientes;

        [BindProperty]
        public Cliente cliente  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public EditModel()
        {
            this.repositorioClientes  =new RepositorioClientes(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? clienteId)
        {
            if (clienteId.HasValue)
            {
                cliente = repositorioClientes.GetCliente(clienteId.Value);
            }
            else
            {
                cliente = new Cliente();
            }

            if (cliente == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }

        //se ejecuta al presionar Editar en el formulario
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(cliente.id > 0)
            {
                try{
                    cliente = repositorioClientes.UpdateCliente( cliente ); 
                    Mensaje = "Registro actualizado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al Actualizar el Registro";
                }
            }
            else
            {
                try{
                    repositorioClientes.AddCliente( cliente );
                    Mensaje = "Registro creado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al crear el Registro";
                }               
            }
            return Page();
        }
    }
}
