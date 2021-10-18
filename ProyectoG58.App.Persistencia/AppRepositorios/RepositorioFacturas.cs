using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;

namespace ProyectoG58.App.Persistencia
{
    public class RepositorioFacturas : IRepositorioFacturas
    {
         private readonly AppContext _appContext;

         public RepositorioFacturas(AppContext appContext)
         {
            _appContext = appContext;
         }

       //Métodos 

        Factura IRepositorioFacturas.AddFactura(Factura factura)
        {
            var facturaAdicionada = _appContext.Factura.Add(factura);
            _appContext.SaveChanges();
            return facturaAdicionada.Entity;
        }

        IEnumerable<Factura> IRepositorioFacturas.GetAllFacturas()
        {
            return _appContext.Factura;
        }

        Factura IRepositorioFacturas.GetFactura(int idFactura)
        {
            return _appContext.Factura.FirstOrDefault(p => p.id == idFactura);
        }

        Factura IRepositorioFacturas.UpdateFactura(Factura factura)
        {
            var facturaEncontrada= _appContext.Factura.FirstOrDefault(p => p.id == factura.id);
            if (facturaEncontrada!= null)
            {
                facturaEncontrada.fecha = factura.fecha;
                facturaEncontrada.tipo= factura.tipo;
                facturaEncontrada.saldo = factura.saldo;
                facturaEncontrada.clienteId = factura.clienteId;
                facturaEncontrada.empleadoId = factura.empleadoId;
                facturaEncontrada.estado = factura.estado;

                _appContext.SaveChanges();
            }
            return facturaEncontrada;
        }

        void IRepositorioFacturas.DeleteFactura(int idFactura)
        {
            var facturaEncontrada= _appContext.Factura.FirstOrDefault(p => p.id == idFactura);
            if (facturaEncontrada== null)
                return;
            _appContext.Factura.Remove(facturaEncontrada);
            _appContext.SaveChanges();
        }
       
    }
}
