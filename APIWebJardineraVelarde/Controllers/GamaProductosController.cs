using APIWebJardineraVelarde.Helpers;
using APIWebJardineraVelarde.Models;
using APIWebJardineraVelarde.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebJardineraVelarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamaProductosController : ControllerBase
    {
        Datos db = new Datos();//Conexion a la BD global a la base de datos para todos los metodos
        Respuesta resultado = new Respuesta();

        // GET: api/<GamaProductosController>
        [HttpGet("Todas las Gamas")]
        public ActionResult<string> BuscarTodas()
        {
            Respuesta resultado = new Respuesta();
            try
            {
                List<GamaProductosIdViewModel> lista = new List<GamaProductosIdViewModel>();

                foreach (Gama_Productos c in db.gama_producto)
                {
                    lista.Add(new GamaProductosIdViewModel(c));
                }

                if (lista.Count == 0)
                {
                    throw new Exceptions("No hay Gamas de productos para mostrar");
                }
                resultado.Info = lista;
            }
            catch (Exceptions ex)
            {
                resultado.Estado = false;
                resultado.Mensaje = ex.Message;
            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Error consulta al administrador";
            }

            return Ok(resultado);
        }

        // GET api/<GamaProductoController>/5
        [HttpGet("Buscar/{id}")]
        public ActionResult Buscar(string gama)
        {
            Gama_Productos BuscarGama;
            Respuesta resultado = new Respuesta();
            try
            {
                BuscarGama = db.gama_producto.Find(gama);
                if (BuscarGama != null)
                {
                    resultado.Info = new GamaProductosIdViewModel(BuscarGama);
                }
                else
                {
                    throw new Exceptions("no gama solicitada");
                }
            }
            catch (Exceptions ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Mensaje = "Error consulta al administrador";
            }

            return Ok(resultado);
        }

        // POST api/<GamaProductoController>
        [HttpPost("Nueva")]
        public ActionResult Nuevo([FromBody] GamaProductosViewModel g)
        {
            Gama_Productos nueva = new Gama_Productos(g);
            Respuesta resultado = new Respuesta();
            try
            {

                db.gama_producto.Add(nueva);

                db.SaveChanges();
                resultado.Info = new GamaProductosIdViewModel(nueva);
            }
            catch (Exception)
            {
                resultado.Mensaje = "Error en el sistma consultar DBA";
            }
            return Ok(resultado);
        }

        // PUT api/<GamaProductoController>/5
        [HttpPut("Actualizar/{id}")]
        public ActionResult Put(string gama, [FromBody] Gama_Productos g)
        {
            Respuesta resultado = new Respuesta();
            try
            {
                Gama_Productos BuscarGama = db.gama_producto.Find(gama);

                if (BuscarGama != null)
                {
                    BuscarGama.descripcion_texto = g.descripcion_texto;
                    BuscarGama.descripcion_html = g.descripcion_html;
                    BuscarGama.imagen = g.imagen;
                    db.SaveChanges();
                    resultado.Info = new GamaProductosIdViewModel(BuscarGama);
                }
                else
                {
                    throw new Exception("La categoria no fue encontrada");
                }
            }
            catch (Exceptions ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Mensaje = "Error en el sistema consulta DBA";
            }

            return Ok(resultado);
        }

        // DELETE api/<GamaProductoController>/5
        [HttpDelete("Eliminar/{id}")]
        public ActionResult Delete(string gama)
        {
            Respuesta resultado = new Respuesta();
            Gama_Productos BuscarGama = db.gama_producto.Find(gama);
            try
            {
                if (BuscarGama != null)
                {
                    db.gama_producto.Remove(BuscarGama);
                    db.SaveChanges();
                    resultado.Info = (new GamaProductosIdViewModel(BuscarGama));
                }
                else
                {
                    throw new Exception("Ctegoria no encontrada");
                }
            }
            catch (Exception)
            {
                resultado.Mensaje = "error en el sistema";
            }
            return Ok(resultado);
        }
    }
}
