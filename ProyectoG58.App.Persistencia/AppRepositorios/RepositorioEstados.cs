using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;

namespace ProyectoG58.App.Persistencia
{
    public class RepositorioEstados : IRepositorioEstados
    {
         private readonly AppContext _appContext;

        public RepositorioEstados(AppContext appContext)
         {
            _appContext = appContext;
         }

       //Métodos 

        Estado IRepositorioEstados.AddEstado(Estado estado)
        {
            var estadoAdicionado = _appContext.Estado.Add(estado);
            _appContext.SaveChanges();
            return estadoAdicionado.Entity;
        }

        IEnumerable<Estado> IRepositorioEstados.GetAllEstados()
        {
            return _appContext.Estado;
        }

        Estado IRepositorioEstados.GetEstado(int idEstado)
        {
            return _appContext.Estado.FirstOrDefault(p => p.id == idEstado);
        }

        Estado IRepositorioEstados.UpdateEstado(Estado estado)
        {
            var estadoEncontrado = _appContext.Estado.FirstOrDefault(p => p.id == estado.id);
            if (estadoEncontrado!= null)
            {
                estadoEncontrado.codigo = estado.codigo;
                estadoEncontrado.nombre= estado.nombre;
                estadoEncontrado.fechaRegistro = estado.fechaRegistro;

                _appContext.SaveChanges();
            }
            return estadoEncontrado;
        }

        void IRepositorioEstados.DeleteEstado(int idEstado)
        {
            var estadoEncontrado = _appContext.Estado.FirstOrDefault(p => p.id == idEstado);
            if (estadoEncontrado== null)
                return;
            _appContext.Estado.Remove(estadoEncontrado);
            _appContext.SaveChanges();
        }
       
    }
}
