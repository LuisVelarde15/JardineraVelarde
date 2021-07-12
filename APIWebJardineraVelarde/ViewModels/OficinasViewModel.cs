using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.ViewModels
{
    public class OficinasViewModel
    {
        public string Codigo_Oficina { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Region { get; set; }
        public string Codigo_postal { get; set; }
        public string Telefono { get; set; }
        public string Linea_Direccion1 { get; set; }
        public string Linea_Direccion2 { get; set; }

        public OficinasViewModel()
        {
        }

        public OficinasViewModel(string Codigo_Oficina, string Ciudad, string Pais, string Region,
         string Codigo_postal, string Telefono, string Linea_Direccion1, string Linea_Direccion2)
        {
            this.Codigo_Oficina = Codigo_Oficina;
            this.Ciudad = Ciudad;
            this.Pais = Pais;
            this.Region = Region;
            this.Codigo_postal = Codigo_postal;
            this.Telefono = Telefono;
            this.Linea_Direccion1 = Linea_Direccion1;
            this.Linea_Direccion2 = Linea_Direccion2;
        }
    }
}
