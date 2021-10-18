using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioProductoFacturas
    {
        IEnumerable<ProductoFactura> GetAllProductoFacturas();
        ProductoFactura AddProductoFactura(ProductoFactura productoFactura);
        ProductoFactura UpdateProductoFactura(ProductoFactura productoFactura);
        void DeleteProductoFactura(int idProductoFactura);    
        ProductoFactura GetProductoFactura(int idProductoFactura);
    }
     
}
