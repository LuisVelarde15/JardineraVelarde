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
        //[ForeignKey("gama_producto")]
        public string gama { get; set; }
        public string nombre { get; set; }
        public string dimensiones { get; set; }
        public string proveedor { get; set; }
        public string descripcion { get; set; }
        public Int16 cantidad_en_stock { get; set; }
        public int precio_venta { get; set; }
        public int precio_provedor { get; set; }

        public Producto()
        {

        }

        public Producto(string gama, string codigo_producto, string nombre, string dimensiones, string proveedor,
            string descripcion, Int16 cantidad_en_stock, int precio_venta, int precio_proveedor)
        {
            this.gama = gama;
            this.codigo_producto = codigo_producto;
            this.nombre = nombre;
            this.dimensiones = dimensiones;
            this.proveedor = proveedor;
            this.descripcion = descripcion;
            this.cantidad_en_stock = cantidad_en_stock;
            this.precio_venta = precio_venta;
            this.precio_provedor = precio_provedor;
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

        
    }
}
