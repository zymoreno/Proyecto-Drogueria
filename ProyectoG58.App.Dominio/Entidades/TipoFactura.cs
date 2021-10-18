using System;

namespace ProyectoG58.App.Dominio
{
    public class TipoFactura
    {
       //geteamos y seteamos todos los atributos de la clase o tabla
       //ahora se llaman propiedades
        public int id { get; set; }
        public string descripcion { get; set; }
        public string fechaRegistro {get; set;}
        public string estado { get; set; }
    }
}