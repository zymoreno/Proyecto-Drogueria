using System;

namespace ProyectoG58.App.Dominio
{
    public class Estado
    {
       //geteamos y seteamos todos los atributos de la clase o tabla
       //ahora se llaman propiedades
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string fechaRegistro { get; set;}
    }
}