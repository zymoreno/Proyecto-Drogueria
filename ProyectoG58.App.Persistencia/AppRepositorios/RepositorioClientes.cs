using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;

namespace ProyectoG58.App.Persistencia
{
    public class RepositorioClientes : IRepositorioClientes
    {
         private readonly AppContext _appContext;
         public IEnumerable<Cliente> clientes {get; set;} 

        public RepositorioClientes(AppContext appContext)
         {
            _appContext = appContext;
         }

       //Métodos 

        Cliente IRepositorioClientes.AddCliente(Cliente cliente)
        {
            var ClienteAdicionado = _appContext.Cliente.Add(cliente);
            _appContext.SaveChanges();
            return ClienteAdicionado.Entity;
        }

        IEnumerable<Cliente> IRepositorioClientes.GetAllClientes(string? nombre)
        {
            if (nombre != null) {
              clientes = _appContext.Cliente.Where(p => p.nombre.Contains(nombre)); //like sobre la tabla
            }
            else 
               clientes = _appContext.Cliente;  //select * from tutor
            return clientes;
        }

        Cliente IRepositorioClientes.GetCliente(int idCliente)
        {
            return _appContext.Cliente.FirstOrDefault(p => p.id == idCliente);
        }

        Cliente IRepositorioClientes.UpdateCliente(Cliente cliente)
        {
            var ClienteEncontrado = _appContext.Cliente.FirstOrDefault(p => p.id == cliente.id);
            if (ClienteEncontrado!= null)
            {
                ClienteEncontrado.nombre = cliente.nombre;
                ClienteEncontrado.identificacion = cliente.identificacion;
                ClienteEncontrado.direccion = cliente.direccion;
                ClienteEncontrado.telefono = cliente.telefono;
                ClienteEncontrado.email = cliente.email;
                ClienteEncontrado.estado = cliente.estado;

                _appContext.SaveChanges();
            }
            return ClienteEncontrado;
        }

        void IRepositorioClientes.DeleteCliente(int idCliente)
        {
            var ClienteEncontrado = _appContext.Cliente.FirstOrDefault(p => p.id == idCliente);
            if (ClienteEncontrado== null)
                return;
            _appContext.Cliente.Remove(ClienteEncontrado);
            _appContext.SaveChanges();
        }
       
    }
}
