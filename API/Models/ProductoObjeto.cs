using System.ComponentModel.DataAnnotations.Schema;
namespace API
    {  
    public class ProductoObjeto
    {
        
      public int ID {get; set;}
      public int IDPedido {get; set;}
      public int IDProducto{ get;set;}
      public int Cantidad{ get; set; }

        public ProductoObjeto(int id, int cantidad){
            IDProducto = id;
            Cantidad= cantidad;
        }
         public ProductoObjeto(){}
    }
}