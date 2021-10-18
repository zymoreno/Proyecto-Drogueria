using System;

namespace ProyectoG58.App.Dominio
{
    public class Cliente
    {
       //geteamos y seteamos todos los atributos de la clase o tabla
       //ahora se llaman propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public int identificacion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string estado { get; set; }
    }
}