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
    public class DeleteModelUser : PageModel
    {
        private readonly IRepositorioEmpleados repositorioEmpleados;

        [BindProperty]
        public Empleado empleado  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public DeleteModelUser(){
             this.repositorioEmpleados  =new RepositorioEmpleados(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int empleadoId)
        {
            empleado = repositorioEmpleados.GetEmpleado(empleadoId);
            if(empleado == null)
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
            if(empleado.id > 0)
            {
                try{
                   repositorioEmpleados.DeleteEmpleado(empleado.id);
                    Mensaje = "Registro eliminado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al eliminar el Registro";
                }
               
            }
            return Page();
        }
    }
}
