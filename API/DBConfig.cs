using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace API
{    
    public class BaseDeDatosContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }    
        public DbSet<Producto> Productos { get; set; }    
        public DbSet<Pedido> Pedidos { get; set; }    
         public DbSet<ProductoObjeto> ProductoObjeto { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=BaseDeDatos.db");//Nombre de base de datos
    }
}