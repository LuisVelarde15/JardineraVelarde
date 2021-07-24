using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.ViewModels
{
    public class ProductosIdViewModel
    {
        //[Key]
        public string codigo_producto { get; set; }
        public string nombre { get; set; }
        public string dimensiones { get; set; }
        public string proveedor { get; set; }
        public string descripcion { get; set; }
        public int cantidad_en_stock { get; set; }
        public int precio_venta { get; set; }
        public int precio_provedor { get; set; }

        public ProductosIdViewModel()
        {

        }
    }
}
