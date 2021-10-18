using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Collections;
using System.Net.WebSockets;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoG58.App.Dominio;
using ProyectoG58.App.Persistencia;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoG58.App.Presentacion
{
    public class NewSaleModel : PageModel
    {
        private readonly IRepositorioClientes repositorioClientes;
        private readonly IRepositorioProductos repositorioProductos;
        [BindProperty]
        public IEnumerable<Cliente> clientes {get;set;}
        public IEnumerable<Producto> productos {get;set;}
        /*public NewSaleModel(Cliente clienteId) 
        {
            this.clienteId = clienteId;
               
        }*/
        [BindProperty]
        public Cliente clienteId {get;set;}
        int cliId = 0;
        //int identificacion_ = 0;

        /*[DataType(DataType.Text)]
        [DisplayName("Users")]
        [UIHint("List")]
        public List<SelectListItem> userslista { get; set;}*/
       
        public NewSaleModel(){

            this.repositorioClientes=new RepositorioClientes(new ProyectoG58.App.Persistencia.AppContext());
            this.repositorioProductos=new RepositorioProductos(new ProyectoG58.App.Persistencia.AppContext());
            this.clienteId = clienteId;
            //this.identificacion_= 0;

            
        }
        public void OnGet()
        {
            productos= repositorioProductos.GetAllProductos(null);
            clientes = repositorioClientes.GetAllClientes(null);
            clienteId = repositorioClientes.GetCliente(cliId);
            
        }

        public int obtenerCliente( String cliId ){
            
            clienteId = repositorioClientes.GetCliente(1);
            System.Console.WriteLine(clienteId.identificacion);
            clienteId.identificacion = clienteId.identificacion;
            return clienteId.identificacion;
        }    
        
    }
}
