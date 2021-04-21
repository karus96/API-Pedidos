using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace API
{
    public class PedidoRespository{
        private BaseDeDatosContext db;

        public PedidoRespository(){
            db=new BaseDeDatosContext();            
        }
        public List<ProductoObjeto> OptenerProductos(int idpedido){         
            List<ProductoObjeto> respuesta=new List<ProductoObjeto>();
            foreach (var item in db.ProductoObjeto.ToList())
            {
                if(item.IDPedido==idpedido)
                    respuesta.Add(item);
            }
            return respuesta;
        }
        public List<Pedido> OptenerPedidos(){
            List<Pedido> pedidos=db.Pedidos.ToList();
            foreach (var item in pedidos )
            {
                item.Productos=OptenerProductos(item.ID);
            }
           return pedidos;           
        }
        public string AgregarPedido(Pedido Pedido){
            try
            {
                var result= db.Pedidos.Add(Pedido);
            foreach (var item in Pedido.Productos)
            {
                db.ProductoObjeto.Add(item);
               
            }
             db.SaveChanges();  
            return "Pedido agregado:  " + result.Entity.ID;
            }
            catch (System.Exception e)
            {
                return e.ToString();
              
            }
           
        }

        public string BorrarPedido(int id)
        {            
          
           foreach (var item in db.ProductoObjeto)
           {
              if(item.IDPedido==id){
                db.ProductoObjeto.Remove(db.ProductoObjeto.Find(item.ID));
              }
           }
            db.Pedidos.Remove(db.Pedidos.Find(id));
            db.SaveChanges();             
            return "Pedido borrado con el: "+id;
        }
        public Pedido OptenerPedido(int id){
            var x=db.Pedidos.Find(id);
            return db.Pedidos.Find(id);
        }
     
    }
}