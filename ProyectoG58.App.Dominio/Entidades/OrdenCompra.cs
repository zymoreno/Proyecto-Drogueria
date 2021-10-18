using System;

namespace ProyectoG58.App.Dominio
{
    public class OrdenCompra
    {
       //geteamos y seteamos todos los atributos de la clase o tabla
       //ahora se llaman propiedades
        public int id { get; set; }
        public string fecha { get; set; }
        public int bodegaId { get; set; }
        public int proveedorId { get; set; }
        public string estado { get; set; }
    }
}