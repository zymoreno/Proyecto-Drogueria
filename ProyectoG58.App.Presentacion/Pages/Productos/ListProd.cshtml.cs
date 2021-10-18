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
    public class ListProdModel : PageModel
    {
        private readonly IRepositorioProductos repositorioProductos;

        public IEnumerable<Producto> productos {get;set;}

        public string searchString; 
       
        public ListProdModel(){

            this.repositorioProductos=new RepositorioProductos(new ProyectoG58.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            productos =repositorioProductos.GetAllProductos(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            productos = repositorioProductos.GetAllProductos(searchString);
            return Page();
        }
    }
}
