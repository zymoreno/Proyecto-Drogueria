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
    public class DetailsModelEmpl : PageModel
    {
        private readonly IRepositorioEmpleados repositorioEmpleados;
        public Empleado empleado { get; set; }

        public DetailsModelEmpl()
        {
            this.repositorioEmpleados=new RepositorioEmpleados(new ProyectoG58.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int empleadoId)
        {
            empleado = repositorioEmpleados.GetEmpleado(empleadoId);
            if(empleado==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
