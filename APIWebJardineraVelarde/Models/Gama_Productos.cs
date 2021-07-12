using APIWebJardineraVelarde.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace APIWebJardineraVelarde.Models
{
    public class Gama_Productos
    {
        [Key]
        public string gama { get; set; }
        public string descripcion_texto { get; set; }
        public string descripcion_html { get; set; }
        public string imagen { get; set; }
        public Gama_Productos()
        {
        }
        public Gama_Productos(string gama, string descripcion_texto, string descripcion_html, string imagen)
        {
            this.gama = gama;
            this.descripcion_texto = descripcion_texto;
            this.descripcion_html = descripcion_html;
            this.imagen = imagen;
        }

        public Gama_Productos(GamaProductosViewModel g)
        {
            this.gama = g.gama;
            this.descripcion_texto = g.descripcion_texto;
            this.descripcion_html = g.descripcion_html;
            this.imagen = g.imagen;
        }

    }
}
