using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.Helpers
{
    public class Exceptions :  Exception
    {
        public Exceptions(string Mensaje) : base(Mensaje)
        {

        }
    }
}
