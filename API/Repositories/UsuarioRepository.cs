using System.Collections.Generic;
using System.Linq;
namespace API
{
    public class UsuarioRespository{
        private BaseDeDatosContext db;

        public UsuarioRespository(){
            db=new BaseDeDatosContext();
        }

        public List<Usuario> OptenerUsuarios(){
            return db.Usuarios.ToList();
        }
        public string AgregarUsuario(Usuario usuario){
            usuario.EstablecerID();
            var result= db.Usuarios.Add(usuario);
            db.SaveChanges();             
            return "Usuario agregado:  " + result.Entity.Correo;
        }

        public string BorrarUsuario(string correo)
        {        
            if(correo!=null)    
            {
                db.Usuarios.Remove(db.Usuarios.Find(correo));
                db.SaveChanges();             
                return "Usuario borrado con el Correo: "+correo;
            }
            return "Correo no valido o inexistente"           ;
        }
        public Usuario OptenerUsuario(string correo){
            var x=db.Usuarios.Find(correo);
            return db.Usuarios.Find(correo);
        }
     
    }
}