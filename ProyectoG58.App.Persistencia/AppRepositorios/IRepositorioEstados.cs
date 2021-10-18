using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioEstados
    {
        IEnumerable<Estado> GetAllEstados();
        Estado AddEstado(Estado estado);
        Estado UpdateEstado(Estado estado);
        void DeleteEstado(int idEstado);    
        Estado GetEstado(int idEstado);
    }
     
}
