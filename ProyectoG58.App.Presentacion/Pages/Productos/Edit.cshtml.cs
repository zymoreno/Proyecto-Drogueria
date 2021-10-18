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
    public class EditModelProd : PageModel
    {
        private readonly IRepositorioProductos repositorioProductos;

        [BindProperty]
        public Producto producto  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public EditModelProd()
        {
            this.repositorioProductos  =new RepositorioProductos(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? productoId)
        {
            if (productoId.HasValue)
            {
                producto = repositorioProductos.GetProducto(productoId.Value);
            }
            else
            {
                producto = new Producto();
            }

            if (producto == null)
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
            if(producto.id > 0)
            {
                try{
                    producto = repositorioProductos.UpdateProducto( producto ); 
                    Mensaje = "Registro actualizado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al Actualizar el Registro";
                }
            }
            else
            {
                try{
                    repositorioProductos.AddProducto( producto );
                    Mensaje = "Registro creado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al crear el Registro";
                }               
            }
            return Page();
        }
    }
}
