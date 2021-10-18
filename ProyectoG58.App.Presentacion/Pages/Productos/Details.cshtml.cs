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
    public class DetailsModelProd : PageModel
    {
        private readonly IRepositorioProductos repositorioProductos;
        public Producto producto { get; set; }

        public DetailsModelProd()
        {
            this.repositorioProductos=new RepositorioProductos(new ProyectoG58.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int productoId)
        {
            producto = repositorioProductos.GetProducto(productoId);
            if(producto==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
