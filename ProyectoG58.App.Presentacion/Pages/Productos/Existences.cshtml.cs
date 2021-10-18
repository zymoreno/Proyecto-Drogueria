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
    public class ExistencesModel : PageModel
    {
        private readonly IRepositorioBodega repositorioBodega;

        public IEnumerable<Bodega> bodega {get;set;}

        public string searchString; 
       
        public ExistencesModel(){

            this.repositorioBodega=new RepositorioBodega(new ProyectoG58.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            bodega =repositorioBodega.GetAllBodegas(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            bodega = repositorioBodega.GetAllBodegas(searchString);
            return Page();
        }
    }
}
