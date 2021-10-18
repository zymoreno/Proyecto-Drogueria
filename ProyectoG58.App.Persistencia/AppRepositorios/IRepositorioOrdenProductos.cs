using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioOrdenProductos
    {
        IEnumerable<OrdenProducto> GetAllOrdenProductos();
        OrdenProducto AddOrdenProducto(OrdenProducto ordenProducto);
        OrdenProducto UpdateOrdenProducto(OrdenProducto ordenProducto);
        void DeleteOrdenProducto(int idOrdenProducto);    
        OrdenProducto GetOrdenProducto(int idOrdenProducto);
    }
     
}
