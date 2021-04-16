namespace API
    {      
    public class Producto
    {   
        public int Id {get; set;}
        public string Nombre {get; set;}
        public float Precio {get; set;}        
        public string Descripcion {get; set;}
 
        public Producto(int id, string nombre, float precio, string descripcion)
        {
           Id=id;
           Nombre= nombre;
           Precio= precio;
           Descripcion= descripcion;
        }
        public Producto(){}
    }
}