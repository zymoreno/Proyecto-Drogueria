using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;

namespace ProyectoG58.App.Persistencia
{
    public class RepositorioTipoTipoFacturas : IRepositorioTipoTipoFacturas
    {
         private readonly AppContext _appContext;

        public RepositorioTipoTipoFacturas(AppContext appContext)
         {
            _appContext = appContext;
         }

       //Métodos 

        TipoFactura IRepositorioTipoTipoFacturas.AddTipoFactura(TipoFactura tipoFactura)
        {
            var tipoFacturaAdicionada = _appContext.TipoFactura.Add(tipoFactura);
            _appContext.SaveChanges();
            return tipoFacturaAdicionada.Entity;
        }

        IEnumerable<TipoFactura> IRepositorioTipoTipoFacturas.GetAllTipoTipoFacturas()
        {
            return _appContext.TipoFactura;
        }

        TipoFactura IRepositorioTipoTipoFacturas.GetTipoFactura(int idTipoFactura)
        {
            return _appContext.TipoFactura.FirstOrDefault(p => p.id == idTipoFactura);
        }

        TipoFactura IRepositorioTipoTipoFacturas.UpdateTipoFactura(TipoFactura tipoFactura)
        {
            var tipoFacturaEncontrada= _appContext.TipoFactura.FirstOrDefault(p => p.id == tipoFactura.id);
            if (tipoFacturaEncontrada!= null)
            {
                tipoFacturaEncontrada.descripcion = tipoFactura.descripcion;
                tipoFacturaEncontrada.fechaRegistro= tipoFactura.fechaRegistro;
                tipoFacturaEncontrada.estado = tipoFactura.estado;

                _appContext.SaveChanges();
            }
            return tipoFacturaEncontrada;
        }

        void IRepositorioTipoTipoFacturas.DeleteTipoFactura(int idTipoFactura)
        {
            var tipoFacturaEncontrada= _appContext.TipoFactura.FirstOrDefault(p => p.id == idTipoFactura);
            if (tipoFacturaEncontrada== null)
                return;
            _appContext.TipoFactura.Remove(tipoFacturaEncontrada);
            _appContext.SaveChanges();
        }
       
    }
}
