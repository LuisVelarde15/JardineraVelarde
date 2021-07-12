using APIWebJardineraVelarde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.ViewModels
{
    public class GamaProductosViewModel
    {
        public string gama { get; set; }
        public string descripcion_texto { get; set; }
        public string descripcion_html { get; set; }
        public string imagen { get; set; }
        public GamaProductosViewModel()
        {
        }
        public GamaProductosViewModel(string gama, string descripcion_texto)
        {
            this.gama = gama;

            this.descripcion_texto = descripcion_texto;
        }

        public GamaProductosViewModel(string gama, string descripcion_texto, string descripcion_html, string imagen)
        {
            this.gama = gama;
            this.descripcion_texto = descripcion_texto;
            this.descripcion_html = descripcion_html;
            this.imagen = imagen;
        }
    }
}
