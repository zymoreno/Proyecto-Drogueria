using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioBodega
    {
        IEnumerable<Bodega> GetAllBodegas(string? nombre);
        Bodega AddBodega(Bodega bodega);
        Bodega UpdateBodega(Bodega bodega);
        void DeleteBodega(int idBodega);    
        Bodega GetBodega(int idBodega);
    }
     
}
