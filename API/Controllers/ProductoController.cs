using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace API
{
    [ApiController]
    [Route("[controller]")]

    public class ProductoController: ControllerBase
    {    
        private ProductoRespository productoRespostory;

        public ProductoController(){
            productoRespostory=new ProductoRespository();
        }        
        [HttpGet]
        public  List<Producto> ObtenerProductos()
        {
                return productoRespostory.OptenerProductos();
        }    
        [HttpGet]
        [Route("{OptenerProductoPorID}")]
        public Producto OptenerProductoPorID([FromQuery]int id){
            return productoRespostory.OptenerProducto(id);
        }
        [HttpPost]
        public string AgregarProducto([FromBody] Producto producto)
        {            
            return productoRespostory.AgregarProducto(producto);
        }

        [HttpPut]
          [Route("{ActualizarProducto}")]
        public string ActualizarProducto( [FromBody]Producto producto)
        {
            Producto nProducto=  productoRespostory.OptenerProducto(producto.Id);
            productoRespostory.BorrarProducto(producto.Id);
            productoRespostory.AgregarProducto(producto);
            return "Producto actualizado: "+producto.Id;
        }
        [HttpDelete]
        public string BorrarProducto([FromQuery] int id)
        {            
            return productoRespostory.BorrarProducto(id);
        }
    }    
}