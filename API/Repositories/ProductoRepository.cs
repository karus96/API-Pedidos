using System.Collections.Generic;
using System.Linq;
namespace API
{
    public class ProductoRespository{
        private BaseDeDatosContext db;

        public ProductoRespository(){
            db=new BaseDeDatosContext();
        }

        public List<Producto> OptenerProductos(){
            return db.Productos.ToList();
        }
        public string AgregarProducto(Producto producto){
           var result= db.Productos.Add(producto);
            db.SaveChanges();             
            return "Producto agregado:  " + result.Entity.Id;
        }

        public string BorrarProducto(int id)
        {            
            db.Productos.Remove(db.Productos.Find(id));
            db.SaveChanges();             
            return "Producto borrado con el: "+id;
        }
        public Producto OptenerProducto(int id){
            var x=db.Productos.Find(id);
            return db.Productos.Find(id);
        }
     
    }
}