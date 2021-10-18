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
    public class EditModelUser : PageModel
    {
        private readonly IRepositorioEmpleados repositorioEmpleados;

        [BindProperty]
        public Empleado empleado  { get; set; } 

        [TempData]
        public string Mensaje { get; set; } 

        public EditModelUser()
        {
            this.repositorioEmpleados  =new RepositorioEmpleados(new ProyectoG58.App.Persistencia.AppContext());
        }
        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? empleadoId)
        {
            if (empleadoId.HasValue)
            {
                empleado = repositorioEmpleados.GetEmpleado(empleadoId.Value);
            }
            else
            {
                empleado = new Empleado();
            }

            if (empleado == null)
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
            if(empleado.id > 0)
            {
                try{
                    empleado = repositorioEmpleados.UpdateEmpleado( empleado ); 
                    Mensaje = "Registro actualizado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al Actualizar el Registro";
                }
            }
            else
            {
                try{
                    repositorioEmpleados.AddEmpleado( empleado );
                    Mensaje = "Registro creado Correctamente";
                }catch{
                    Mensaje= "Ocurrio un Error al crear el Registro";
                }               
            }
            return Page();
        }
    }
}
