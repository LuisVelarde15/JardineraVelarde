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
        public string nombre { get; set; }
        public string gama { get; set; }//FK
        public string dimensiones { get; set; }
        public string proveedor { get; set; }
        public string descripcion { get; set; }
        public Int16 cantidad_en_stock { get; set; }
        public decimal precio_venta { get; set; }
        public decimal precio_proveedor { get; set; }

        public Producto()
        {

        }

        public Producto(string nombre, string gama, string dimensiones, string proveedor, string descripcion,
            Int16 cantidad_en_stock, decimal precio_venta, decimal precio_proveedor)
        {
            this.nombre = nombre;
            this.gama = gama;
            this.dimensiones = dimensiones;
            this.proveedor = proveedor;
            this.descripcion = descripcion;
            this.cantidad_en_stock = cantidad_en_stock;
            this.precio_venta = precio_venta;
            this.precio_proveedor = precio_proveedor;

        }

        public Producto(ProductosViewModel p)
        {
            this.codigo_producto = p.codigo_producto;
            this.nombre = p.nombre;
            this.gama = p.gama;
            this.dimensiones = p.dimensiones;
            this.proveedor = p.proveedor;
            this.descripcion = p.descripcion;
            this.cantidad_en_stock = p.cantidad_en_stock;
            this.precio_venta = p.precio_venta;
            this.precio_proveedor = p.precio_proveedor;
        }

    }
}
