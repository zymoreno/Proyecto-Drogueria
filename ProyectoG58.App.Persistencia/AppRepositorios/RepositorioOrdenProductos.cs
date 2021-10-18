using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;

namespace ProyectoG58.App.Persistencia
{
    public class RepositorioOrdenProductos : IRepositorioOrdenProductos
    {
         private readonly AppContext _appContext;

        public RepositorioOrdenProductos(AppContext appContext)
         {
            _appContext = appContext;
         }

       //Métodos 

        OrdenProducto IRepositorioOrdenProductos.AddOrdenProducto(OrdenProducto ordenProducto)
        {
            var ordenProductoAdicionado = _appContext.OrdenProducto.Add(ordenProducto);
            _appContext.SaveChanges();
            return ordenProductoAdicionado.Entity;
        }

        IEnumerable<OrdenProducto> IRepositorioOrdenProductos.GetAllOrdenProductos()
        {
            return _appContext.OrdenProducto;
        }

        OrdenProducto IRepositorioOrdenProductos.GetOrdenProducto(int idOrdenProducto)
        {
            return _appContext.OrdenProducto.FirstOrDefault(p => p.id == idOrdenProducto);
        }

        OrdenProducto IRepositorioOrdenProductos.UpdateOrdenProducto(OrdenProducto ordenProducto)
        {
            var ordenProductoEncontrado = _appContext.OrdenProducto.FirstOrDefault(p => p.id == ordenProducto.id);
            if (ordenProductoEncontrado!= null)
            {
                ordenProductoEncontrado.cantidad = ordenProducto.cantidad;
                ordenProductoEncontrado.valor= ordenProducto.valor;
                ordenProductoEncontrado.iva = ordenProducto.iva;
                ordenProductoEncontrado.productoId = ordenProducto.productoId;
                ordenProductoEncontrado.ordenCompraId = ordenProducto.ordenCompraId;

                _appContext.SaveChanges();
            }
            return ordenProductoEncontrado;
        }

        void IRepositorioOrdenProductos.DeleteOrdenProducto(int idOrdenProducto)
        {
            var ordenProductoEncontrado = _appContext.OrdenProducto.FirstOrDefault(p => p.id == idOrdenProducto);
            if (ordenProductoEncontrado== null)
                return;
            _appContext.OrdenProducto.Remove(ordenProductoEncontrado);
            _appContext.SaveChanges();
        }
       
    }
}
