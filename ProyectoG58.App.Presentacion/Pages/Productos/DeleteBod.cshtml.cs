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
    public class DeleteBodModel : PageModel
    {
        private readonly IRepositorioBodega repositorioBodega;

        [BindProperty]
        public Bodega bodega  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public DeleteBodModel(){
             this.repositorioBodega  =new RepositorioBodega(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int bodegaId)
        {
            bodega = repositorioBodega.GetBodega(bodegaId);
            if(bodega == null)
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
            if(bodega.id > 0)
            {
                try{
                   repositorioBodega.DeleteBodega(bodega.id);
                    Mensaje = "Registro eliminado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al eliminar el Registro";
                }
               
            }
            return Page();
        }
    }
}
