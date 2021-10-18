using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioTipoTipoFacturas
    {
        IEnumerable<TipoFactura> GetAllTipoTipoFacturas();
        TipoFactura AddTipoFactura(TipoFactura tipoFactura);
        TipoFactura UpdateTipoFactura(TipoFactura tipoFactura);
        void DeleteTipoFactura(int idTipoFactura);    
        TipoFactura GetTipoFactura(int idTipoFactura);
    }
     
}
