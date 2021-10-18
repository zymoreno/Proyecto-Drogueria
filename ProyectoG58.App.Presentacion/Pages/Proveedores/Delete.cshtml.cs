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
    public class DeleteModelProv : PageModel
    {
        private readonly IRepositorioProveedores repositorioProveedores;

        [BindProperty]
        public Proveedor proveedor  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public DeleteModelProv(){
             this.repositorioProveedores  =new RepositorioProveedores(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int proveedorId)
        {
            proveedor = repositorioProveedores.GetProveedor(proveedorId);
            if(proveedor == null)
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
            if(proveedor.id > 0)
            {
                try{
                   repositorioProveedores.DeleteProveedor(proveedor.id);
                    Mensaje = "Registro eliminado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al eliminar el Registro";
                }
               
            }
            return Page();
        }
    }
}
