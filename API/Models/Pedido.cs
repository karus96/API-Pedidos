using System.Collections.Generic;
namespace API
    {      
        public class Pedido
        {
            public int ID {get; set;}
            public string Responsable {get; set;}
            public string NombreCliente {get; set;}
            public string DirecionCliente {get; set;}
            public int TelefonoCliente {get; set;}
            public List<ProductoObjeto> Productos {get; set;}
            public float TotalAPagar {get; set;}
            public string Fecha {get; set;}     
            public Pedido(int id, string responsable, string nombreCliente, string direccionCliente, int telefonoCliente, List<ProductoObjeto> productos, string fecha)
            {
                ID=id;
                Responsable=responsable;
                NombreCliente=nombreCliente;
                DirecionCliente=direccionCliente;
                TelefonoCliente=telefonoCliente;
                Productos= productos;
                TotalAPagar=0;
                Fecha=fecha;           
            }
            public Pedido(){}
        }
    }
