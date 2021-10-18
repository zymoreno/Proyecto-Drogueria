using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;

namespace ProyectoG58.App.Persistencia
{
    public class RepositorioProductoFacturas : IRepositorioProductoFacturas
    {
         private readonly AppContext _appContext;

        public RepositorioProductoFacturas(AppContext appContext)
         {
            _appContext = appContext;
         }

       //Métodos 

        ProductoFactura IRepositorioProductoFacturas.AddProductoFactura(ProductoFactura productoFactura)
        {
            var productoFacturaAdicionado = _appContext.ProductoFactura.Add(productoFactura);
            _appContext.SaveChanges();
            return productoFacturaAdicionado.Entity;
        }

        IEnumerable<ProductoFactura> IRepositorioProductoFacturas.GetAllProductoFacturas()
        {
            return _appContext.ProductoFactura;
        }

        ProductoFactura IRepositorioProductoFacturas.GetProductoFactura(int idProductoFactura)
        {
            return _appContext.ProductoFactura.FirstOrDefault(p => p.id == idProductoFactura);
        }

        ProductoFactura IRepositorioProductoFacturas.UpdateProductoFactura(ProductoFactura productoFactura)
        {
            var productoFacturaEncontrado = _appContext.ProductoFactura.FirstOrDefault(p => p.id == productoFactura.id);
            if (productoFacturaEncontrado!= null)
            {
                productoFacturaEncontrado.cantidad = productoFactura.cantidad;
                productoFacturaEncontrado.valor= productoFactura.valor;
                productoFacturaEncontrado.iva = productoFactura.iva;
                productoFacturaEncontrado.productoId = productoFactura.productoId;
                productoFacturaEncontrado.facturaId = productoFactura.facturaId;

                _appContext.SaveChanges();
            }
            return productoFacturaEncontrado;
        }

        void IRepositorioProductoFacturas.DeleteProductoFactura(int idProductoFactura)
        {
            var productoFacturaEncontrado = _appContext.ProductoFactura.FirstOrDefault(p => p.id == idProductoFactura);
            if (productoFacturaEncontrado== null)
                return;
            _appContext.ProductoFactura.Remove(productoFacturaEncontrado);
            _appContext.SaveChanges();
        }
       
    }
}
