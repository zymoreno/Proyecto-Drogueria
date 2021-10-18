using System;

namespace ProyectoG58.App.Dominio
{
    public class Factura
    {
       //geteamos y seteamos todos los atributos de la clase o tabla
       //ahora se llaman propiedades
        public int id { get; set; }
        public string fecha { get; set; }
        public int tipo { get; set; }
        public double saldo { get; set; }
        public int clienteId { get; set; }
        public int empleadoId { get; set; }
        public string estado { get; set; }
    }
}