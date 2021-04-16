using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace API
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController: ControllerBase
    {
        private UsuarioRespository usuarioRespostory;

        public UsuarioController(){
            usuarioRespostory=new UsuarioRespository();
        }        
        [HttpGet]
        public  List<Usuario> ObtenerUsuarios()
        {
                return usuarioRespostory.OptenerUsuarios();
        }    
        [HttpGet]
        [Route("{OptenerUsuarioPorCorreo}")]
        public Usuario OptenerUsuarioPorCorreo([FromQuery]string correo){
            return usuarioRespostory.OptenerUsuario(correo);
        }
        [HttpPost]
        public string AgregarUsuario([FromBody] Usuario usuario)
        {            
            return usuarioRespostory.AgregarUsuario(usuario);                             
        }

        [HttpPut]
        [Route("{CambiarContraseña}")]
        public string CambiarContraseña([FromBody] Usuario nUsuario)
        {
            Usuario usuario=  usuarioRespostory.OptenerUsuario(nUsuario.Correo);
            usuario.Contraseña=nUsuario.Contraseña;
            usuarioRespostory.BorrarUsuario(nUsuario.Correo);
            usuarioRespostory.AgregarUsuario(usuario);
            return "Usuario cambiado: "+usuario.Correo;
        }
        [HttpDelete]
        public string BorrarUsuario([FromQuery] string correo)
        {            
            return usuarioRespostory.BorrarUsuario(correo);
        }
    }
}