using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioClientes
    {
        IEnumerable<Cliente> GetAllClientes(string? nombre);
        Cliente AddCliente(Cliente cliente);
        Cliente UpdateCliente(Cliente cliente);
        void DeleteCliente(int idCliente);    
        Cliente GetCliente(int idCliente);
    }
     
}
