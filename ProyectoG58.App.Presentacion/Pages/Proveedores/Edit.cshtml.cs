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
    public class EditModelprov : PageModel
    {
        private readonly IRepositorioProveedores repositorioProveedores;

        [BindProperty]
        public Proveedor proveedor  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public EditModelprov()
        {
            this.repositorioProveedores  =new RepositorioProveedores(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? proveedorId)
        {
            if (proveedorId.HasValue)
            {
                proveedor = repositorioProveedores.GetProveedor(proveedorId.Value);
            }
            else
            {
                proveedor = new Proveedor();
            }

            if (proveedor == null)
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
            if(proveedor.id > 0)
            {
                try{
                    proveedor = repositorioProveedores.UpdateProveedor( proveedor ); 
                    Mensaje = "Registro actualizado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al Actualizar el Registro";
                }
            }
            else
            {
                try{
                    repositorioProveedores.AddProveedor( proveedor );
                    Mensaje = "Registro creado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al crear el Registro";
                }               
            }
            return Page();
        }
    }
}
