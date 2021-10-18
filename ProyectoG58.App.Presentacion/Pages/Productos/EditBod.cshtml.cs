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
    public class EditBodModel : PageModel
    {
        private readonly IRepositorioBodega repositorioBodega;

        [BindProperty]
        public Bodega bodega  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public EditBodModel()
        {
            this.repositorioBodega  =new RepositorioBodega(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? bodegaId)
        {
            if (bodegaId.HasValue)
            {
                bodega = repositorioBodega.GetBodega(bodegaId.Value);
            }
            else
            {
                bodega = new Bodega();
            }

            if (bodega == null)
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
            if(bodega.id > 0)
            {
                try{
                    bodega = repositorioBodega.UpdateBodega( bodega ); 
                    Mensaje = "Registro actualizado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al Actualizar el Registro";
                }
            }
            else
            {
                try{
                    repositorioBodega.AddBodega( bodega );
                    Mensaje = "Registro creado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al crear el Registro";
                }               
            }
            return Page();
        }
    }
}
