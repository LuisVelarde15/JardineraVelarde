using APIWebJardineraVelarde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.ViewModels
{
    public class GamaProductosIdViewModel
    {

        public string gama { get; set; }
        public string descripcion_texto { get; set; }
        public string descripcion_html { get; set; }
        public string imagen { get; set; }

        public GamaProductosIdViewModel()
        {
        }

        public GamaProductosIdViewModel(string gama, string descripcion_texto, string descripcion_html, string imagen)
        {
            this.gama = gama;
            this.descripcion_texto = descripcion_texto;
            this.descripcion_html = descripcion_html;
            this.imagen = imagen;
        }
        public GamaProductosIdViewModel(Gama_Productos g)
        {
            this.gama = g.gama;
            this.descripcion_texto = g.descripcion_texto;
            this.descripcion_html = g.descripcion_html;
            this.imagen = g.imagen;
        }
    }
}
