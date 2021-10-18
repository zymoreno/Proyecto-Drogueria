using System;

namespace ProyectoG58.App.Dominio
{
    public class Producto
    {
       //geteamos y seteamos todos los atributos de la clase o tabla
       //ahora se llaman propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public string lote { get; set;}
        public string fechaVencim { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public string presentacion { get; set; }
        public string estado { get; set; }
    }
}