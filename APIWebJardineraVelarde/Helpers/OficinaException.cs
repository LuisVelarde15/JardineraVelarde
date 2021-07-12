using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.Helpers
{
    public class OficinaException : Exception
    {
        public  OficinaException(string Mensaje) : base(Mensaje)
        {
        }
    }
}
