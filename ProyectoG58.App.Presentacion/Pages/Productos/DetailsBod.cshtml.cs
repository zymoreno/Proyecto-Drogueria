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
    public class DetailsBodModel : PageModel
    {
        private readonly IRepositorioBodega repositorioBodega;
        public Bodega bodega { get; set; }

        public DetailsBodModel()
        {
            this.repositorioBodega=new RepositorioBodega(new ProyectoG58.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int bodegaId)
        {
            bodega = repositorioBodega.GetBodega(bodegaId);
            if(bodega==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
