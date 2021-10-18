using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;

namespace ProyectoG58.App.Persistencia
{
    public class RepositorioOrdenCompras : IRepositorioOrdenCompras
    {
         private readonly AppContext _appContext;

        public RepositorioOrdenCompras(AppContext appContext)
         {
            _appContext = appContext;
         }

       //Métodos 

        OrdenCompra IRepositorioOrdenCompras.AddOrdenCompra(OrdenCompra ordenCompra)
        {
            var ordenCompraAdicionada = _appContext.OrdenCompra.Add(ordenCompra);
            _appContext.SaveChanges();
            return ordenCompraAdicionada.Entity;
        }

        IEnumerable<OrdenCompra> IRepositorioOrdenCompras.GetAllOrdenCompras()
        {
            return _appContext.OrdenCompra;
        }

        OrdenCompra IRepositorioOrdenCompras.GetOrdenCompra(int idOrdenCompra)
        {
            return _appContext.OrdenCompra.FirstOrDefault(p => p.id == idOrdenCompra);
        }

        OrdenCompra IRepositorioOrdenCompras.UpdateOrdenCompra(OrdenCompra ordenCompra)
        {
            var ordenCompraEncontrada= _appContext.OrdenCompra.FirstOrDefault(p => p.id == ordenCompra.id);
            if (ordenCompraEncontrada!= null)
            {
                ordenCompraEncontrada.fecha = ordenCompra.fecha;
                ordenCompraEncontrada.bodegaId = ordenCompra.bodegaId;
                ordenCompraEncontrada.proveedorId = ordenCompra.proveedorId;
                ordenCompraEncontrada.estado = ordenCompra.estado;

                _appContext.SaveChanges();
            }
            return ordenCompraEncontrada;
        }

        void IRepositorioOrdenCompras.DeleteOrdenCompra(int idOrdenCompra)
        {
            var ordenCompraEncontrada= _appContext.OrdenCompra.FirstOrDefault(p => p.id == idOrdenCompra);
            if (ordenCompraEncontrada== null)
                return;
            _appContext.OrdenCompra.Remove(ordenCompraEncontrada);
            _appContext.SaveChanges();
        }
       
    }
}
