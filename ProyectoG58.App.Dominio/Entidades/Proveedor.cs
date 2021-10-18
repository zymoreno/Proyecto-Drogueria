using System;

namespace ProyectoG58.App.Dominio
{
    public class Proveedor
    {
       //geteamos y seteamos todos los atributos de la clase o tabla
       //ahora se llaman propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public int nit { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string estado { get; set; }
    }
}