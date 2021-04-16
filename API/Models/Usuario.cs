namespace API
    {  
    public class Usuario
    {
       public string ID { get;set;}
       public string Correo{ get;set;}
       public string Contraseña{ get; set; }

        public Usuario(string correo, string contraseña){
            Correo = correo;
            Contraseña= contraseña;
            ID= Correo;
        }
        public void EstablecerID(){
            ID= Correo;
        }
        public Usuario(){}
    }
}