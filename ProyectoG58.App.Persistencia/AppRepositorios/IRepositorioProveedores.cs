using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioProveedores
    {
        IEnumerable<Proveedor> GetAllProveedores(string? nombre);
        Proveedor AddProveedor(Proveedor proveedor);
        Proveedor UpdateProveedor(Proveedor proveedor);
        void DeleteProveedor(int idProveedor);    
        Proveedor GetProveedor(int idProveedor);
    }
     
}
