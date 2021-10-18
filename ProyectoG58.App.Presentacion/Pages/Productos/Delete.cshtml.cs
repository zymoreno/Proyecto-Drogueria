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
    public class DeleteModelProd : PageModel
    {
        private readonly IRepositorioProductos repositorioProductos;

        [BindProperty]
        public Producto producto  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public DeleteModelProd(){
             this.repositorioProductos  =new RepositorioProductos(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int productoId)
        {
            producto = repositorioProductos.GetProducto(productoId);
            if(producto == null)
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
            if(producto.id > 0)
            {
                try{
                   repositorioProductos.DeleteProducto(producto.id);
                    Mensaje = "Registro eliminado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al eliminar el Registro";
                }
               
            }
            return Page();
        }
    }
}
