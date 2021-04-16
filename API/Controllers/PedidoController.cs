using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace API
{
    [ApiController]
    [Route("[controller]")]

    public class PedidoController: ControllerBase
    {    
         private PedidoRespository pedidoRespostory;
         private ProductoRespository productoRespository;

        public PedidoController(){
            pedidoRespostory=new PedidoRespository();
            productoRespository=new ProductoRespository();
        }        
        [HttpGet]
        public  List<Pedido> ObtenerPedidos()
        {
                return pedidoRespostory.OptenerPedidos();
        }    
        [HttpGet]
        [Route("{correo}")]
        public Pedido OptenerPedidoPorCorreo([FromRoute]int id){
            return pedidoRespostory.OptenerPedido(id);
        }
        [HttpPost]
        public string AgregarPedido([FromBody] Pedido pedido)
        {          
            foreach (var item in pedido.Productos)
            {
                pedido.TotalAPagar+=productoRespository.OptenerProducto(item.IDProducto).Precio*item.Cantidad;
            }
            return pedidoRespostory.AgregarPedido(pedido);
        }
        [HttpPut]
        public string ActualizarPedido( [FromRoute]int id, List<ProductoObjeto> objetos)
        {
            Pedido nPedido=  pedidoRespostory.OptenerPedido(id);
            pedidoRespostory.BorrarPedido(nPedido.ID);
            nPedido.Productos=objetos;
            nPedido.TotalAPagar=0;
            foreach (var item in nPedido.Productos)
            {
                nPedido.TotalAPagar+=productoRespository.OptenerProducto(item.IDProducto).Precio*item.Cantidad;
            }
            pedidoRespostory.AgregarPedido(nPedido);
            return "Procuto actualizado: "+nPedido.ID;
        }
        [HttpDelete]
        public string BorrarPedido([FromQuery] int id)
        {            
            return pedidoRespostory.BorrarPedido(id);
        }
    }    
}