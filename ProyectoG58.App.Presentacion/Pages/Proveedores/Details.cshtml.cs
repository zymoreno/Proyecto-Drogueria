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
    public class DetailsModelProv : PageModel
    {
        private readonly IRepositorioProveedores repositorioProveedores;
        public Proveedor proveedor { get; set; }

        public DetailsModelProv()
        {
            this.repositorioProveedores=new RepositorioProveedores(new ProyectoG58.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int proveedorId)
        {
            proveedor = repositorioProveedores.GetProveedor(proveedorId);
            if(proveedor==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
