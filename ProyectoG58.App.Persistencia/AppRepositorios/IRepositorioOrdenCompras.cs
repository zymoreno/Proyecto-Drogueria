using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioOrdenCompras
    {
        IEnumerable<OrdenCompra> GetAllOrdenCompras();
        OrdenCompra AddOrdenCompra(OrdenCompra ordenCompra);
        OrdenCompra UpdateOrdenCompra(OrdenCompra ordenCompra);
        void DeleteOrdenCompra(int idOrdenCompra);    
        OrdenCompra GetOrdenCompra(int idOrdenCompra);
    }
     
}
