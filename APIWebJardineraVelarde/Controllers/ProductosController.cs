using APIWebJardineraVelarde.Helpers;
using APIWebJardineraVelarde.Models;
using APIWebJardineraVelarde.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebJardineraVelarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        Datos db = new Datos();
        Respuesta Resultado = new Respuesta();

        // GET: api/Productos/Todos
        [HttpGet("(Todos)")]
        public ActionResult Todos()
        {
            Datos db = new Datos();
            Respuesta Resultado = new Respuesta();

            var prod = db.producto;

            var lista = prod.Select(p => new ProductosViewModel
            {
                codigo_producto = p.codigo_producto,
                nombre = p.nombre,
                dimensiones = p.dimensiones,
                proveedor = p.proveedor,
                descripcion = p.descripcion,
                cantidad_en_stock = p.cantidad_en_stock,
                precio_venta = p.precio_venta,
                precio_proveedor = p.precio_proveedor,
                gama = p.gama
            }
            );


            Resultado.Info = lista;

            return Ok(Resultado);

        }


        // GET api/Producto/Buscar
        [HttpGet("Buscar/{id}")]
        public ActionResult Buscar(string id)
        {

            Producto BuscarProducto;
            try
            {
                BuscarProducto = db.producto.Find(id);
                if (BuscarProducto != null)
                    Resultado.Info = new ProductosViewModel(BuscarProducto);
                else
                    throw new Exception("Producto no encontrado");
            }
            catch (Exceptions ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(Resultado);

        }


        // POST api/Gama/Nueva
        [HttpPost("Nuevo")]
        public ActionResult Nuevo([FromBody] ProductosViewModel p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Producto nuevo = new Producto(p);
                    db.producto.Add(nuevo);
                    db.SaveChanges();
                    Resultado.Info = new ProductosViewModel(nuevo);
                }
                else
                {
                    Resultado.Estado = false;
                    string MensajeError = "";

                    foreach (var valor in ModelState.Values)
                    {
                        MensajeError += valor.Errors[0].ErrorMessage;
                        MensajeError += " | ";
                    }
                    Resultado.Mensaje = MensajeError; ;
                }
            }

            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(Resultado);
        }


        // PUT api/Actualizar/id
        [HttpPut("Actualizar/{id}")]
        public ActionResult Actualizar(string id, [FromBody] ProductosViewModel g)
        {

            try
            {
                Producto BuscarProducto = db.producto.Find(id);

                if (BuscarProducto != null)
                {
                    BuscarProducto.nombre = g.nombre;
                    BuscarProducto.gama = g.gama;
                    BuscarProducto.dimensiones = g.dimensiones;
                    BuscarProducto.proveedor = g.proveedor;
                    BuscarProducto.descripcion = g.descripcion;
                    BuscarProducto.cantidad_en_stock = g.cantidad_en_stock;
                    BuscarProducto.precio_venta = g.precio_venta;
                    BuscarProducto.precio_proveedor = g.precio_proveedor;
                    db.SaveChanges();
                    Resultado.Info = new ProductosViewModel(BuscarProducto);

                }
                else
                    throw new Exception("Producto no encontrado");
            }
            catch (Exceptions ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }
            return Ok(Resultado);
        }

        // DELETE api/Inactivar/id
        [HttpDelete("Inactivar/{id}")]
        public ActionResult Inactivar(string id)
        {

            try
            {
                Producto BuscarProducto = db.producto.Find(id);
                if (BuscarProducto != null)
                {
                    db.producto.Remove(BuscarProducto);
                    db.SaveChanges();
                    Resultado.Info = new
                            ProductosViewModel(BuscarProducto);

                }
                else
                    throw new Exception("El producto no fue encontrado");
            }
            catch (Exceptions ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(Resultado);

        }
    }
}
