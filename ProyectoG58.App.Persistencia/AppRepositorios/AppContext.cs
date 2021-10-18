using Microsoft.EntityFrameworkCore;
using ProyectoG58.App.Dominio;

namespace ProyectoG58.App.Persistencia
{
    public class AppContext : DbContext
    {
         public DbSet<Bodega> Bodega { get; set; }
         public DbSet<Cliente> Cliente { get; set; }
         public DbSet<Empleado> Empleado { get; set; }
         public DbSet<Estado> Estado { get; set; }
         public DbSet<Factura> Factura{ get; set; }
         public DbSet<OrdenCompra> OrdenCompra { get; set; }
         public DbSet<OrdenProducto> OrdenProducto { get; set; }
         public DbSet<Producto> Producto { get; set; }
         public DbSet<ProductoFactura> ProductoFactura { get; set; }
         public DbSet<Proveedor> Proveedor { get; set; }
         public DbSet<TipoFactura> TipoFactura { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            if (!optionsBuilder.IsConfigured)
            {


                optionsBuilder
               //.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =ProyectoG58");
                .UseSqlServer("Server=172.16.1.26; Database=ProyectoG58; user id=sa; password=Desa.360");
                //.UseMySQL("server=localhost;port=3306; database=proyectog58;user=lmosquer;password=12345;old guids=true; default command timeout=800;");
            }
        }    
    }
}
