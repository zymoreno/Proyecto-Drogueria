using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public interface IRepositorioEmpleados
    {
        IEnumerable<Empleado> GetAllEmpleados(string? nombre);
        Empleado AddEmpleado(Empleado empleado);
        Empleado UpdateEmpleado(Empleado empleado);
        void DeleteEmpleado(int idEmpleado);    
        Empleado GetEmpleado(int idEmpleado);
    }
     
}
