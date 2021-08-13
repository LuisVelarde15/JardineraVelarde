using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.ViewModels
{
    public class ProductosViewModel
    {

        [Key]
        public string codigo_producto { get; set; }
        [ForeignKey("gama_producto")]
        public string gama { get; set; }
        public string nombre { get; set; }
        public string dimensiones { get; set; }
        public string proveedor { get; set; }
        public string descripcion { get; set; }
        public Int16 cantidad_en_stock { get; set; }
        public int precio_venta { get; set; }
        public int precio_provedor { get; set; }

        public ProductosViewModel()
        {

        }

    }
}
