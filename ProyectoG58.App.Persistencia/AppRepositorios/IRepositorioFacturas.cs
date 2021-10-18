using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioFacturas
    {
        IEnumerable<Factura> GetAllFacturas();
        Factura AddFactura(Factura factura);
        Factura UpdateFactura(Factura factura);
        void DeleteFactura(int idFactura);    
        Factura GetFactura(int idFactura);
    }
     
}
