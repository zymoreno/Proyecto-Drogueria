using System;

namespace ProyectoG58.App.Dominio
{
    public class OrdenProducto
    {
       //geteamos y seteamos todos los atributos de la clase o tabla
       //ahora se llaman propiedades
        public int id { get; set; }
        public int cantidad { get; set; }
        public double valor { get; set; }
        public double iva { get; set; }
        public int productoId { get; set; }
        public int ordenCompraId { get; set; }
    }
}