using System;

namespace ProyectoG58.App.Dominio
{
    public class Empleado
    {
       //geteamos y seteamos todos los atributos de la clase o tabla
       //ahora se llaman propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public int identificacion { get; set; }
        public string cargo { get; set;}
        public string estado { get; set; }
    }
}