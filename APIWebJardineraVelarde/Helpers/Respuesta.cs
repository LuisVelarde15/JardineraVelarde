using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.Helpers
{
    public class Respuesta
    {
        public bool Estado { get; set;}
        public string Mensaje { get; set;}
        public Object Info { get; set;}

        public Respuesta()
        {
            this.Estado = true;
            this.Mensaje = "No hay Error";
            this.Info = null;
        }
        public Respuesta(bool Estado, string Mensaje,Object Info)
        {
            this.Estado = Estado;
            this.Mensaje = Mensaje;
            this.Info = Info;
        }
    }
}
