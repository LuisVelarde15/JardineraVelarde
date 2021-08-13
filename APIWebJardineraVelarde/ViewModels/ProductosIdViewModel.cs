using APIWebJardineraVelarde.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.ViewModels
{
    public class ProductosIdViewModel
    {
        [Key]
        public string codigo_producto { get; set; }
        public string nombre { get; set; }
        public string dimensiones { get; set; }
        public string proveedor { get; set; }
        public string descripcion { get; set; }
        public Int16 cantidad_en_stock { get; set; }
        public int precio_venta { get; set; }
        public int precio_provedor { get; set; }

        public ProductosIdViewModel()
        {

        }
        public ProductosIdViewModel(Producto p)
        {
            codigo_producto = p.codigo_producto;
            nombre = p.nombre;
            dimensiones = p.dimensiones;
            proveedor = p.proveedor;
            descripcion = p.descripcion;
            cantidad_en_stock = p.cantidad_en_stock;
            precio_venta = p.precio_venta;
            precio_provedor = p.precio_provedor;
        }
    }
}
