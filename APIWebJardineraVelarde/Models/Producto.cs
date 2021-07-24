using APIWebJardineraVelarde.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.Models
{
    public class Producto
    {
        [Key]
        public string codigo_producto { get; set; }

        [ForeignKey("gama_producto")]
        public string gama { get; set; }

        public string nombre { get; set; }
        public string dimensiones { get; set; }
        public string proveedor { get; set; }
        public string descripcion { get; set; }
        public int cantidad_en_stock { get; set; }
        public int precio_venta { get; set; }
        public int precio_provedor { get; set; }

        public Producto()
        {

        }

        public Producto(ProductosViewModel p)
        {
            codigo_producto = p.codigo_producto;
            gama = p.gama;
            nombre = p.nombre;
            dimensiones = p.dimensiones;
            proveedor = p.proveedor;
            descripcion = p.descripcion;
            cantidad_en_stock = p.cantidad_en_stock;
            precio_venta = p.precio_venta;
            precio_provedor = p.precio_provedor;
        }

        public Producto(ProductosIdViewModel p)
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
