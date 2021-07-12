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
            Respuesta Resultado = new Respuesta();
            try
            {
                List<GamaProductosIdViewModel> lista = new List<GamaProductosIdViewModel>();

                foreach (Gama_Productos c in db.gama_producto)
                {
                    lista.Add(new GamaProductosIdViewModel(c));
                }

                if (lista.Count == 0)
                {
                    throw new GamaProductoException("No hay Gamas de productos para mostrar");
                }
                Resultado.Info = lista;
            }
            catch (GamaProductoException ex)
            {
                Resultado.Estado = false;
                Resultado.Mensaje = ex.Message;
            }
            catch (Exception)
            {
                Resultado.Estado = false;
                Resultado.Mensaje = "Error consulta al administrador";
            }

            return Ok(Resultado);
        }

        // GET api/<GamaProductoController>/5
        [HttpGet("Buscar/{id}")]
        public ActionResult Buscar(string gama)
        {
            Gama_Productos BuscarGama;
            Respuesta Resultado = new Respuesta();
            try
            {
                BuscarGama = db.gama_producto.Find(gama);
                if (BuscarGama != null)
                {
                    Resultado.Info = new GamaProductosIdViewModel(BuscarGama);
                }
                else
                {
                    throw new GamaProductoException("no gama solicitada");
                }
            }
            catch (GamaProductoException ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error consulta al administrador";
            }

            return Ok(Resultado);
        }

        // POST api/<GamaProductoController>
        [HttpPost("Nueva")]
        public ActionResult Nuevo([FromBody] GamaProductosViewModel g)
        {
            Gama_Productos nueva = new Gama_Productos(g);
            Respuesta Resultado = new Respuesta();
            try
            {

                db.gama_producto.Add(nueva);

                db.SaveChanges();
                Resultado.Info = new GamaProductosIdViewModel(nueva);
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el sistma consultar DBA";
            }
            return Ok(Resultado);
        }

        // PUT api/<GamaProductoController>/5
        [HttpPut("Actualizar/{id}")]
        public ActionResult Put(string gama, [FromBody] Gama_Productos g)
        {
            Respuesta Resultado = new Respuesta();
            try
            {
                Gama_Productos BuscarGama = db.gama_producto.Find(gama);

                if (BuscarGama != null)
                {
                    BuscarGama.descripcion_texto = g.descripcion_texto;
                    BuscarGama.descripcion_html = g.descripcion_html;
                    BuscarGama.imagen = g.imagen;
                    db.SaveChanges();
                    Resultado.Info = new GamaProductosIdViewModel(BuscarGama);
                }
                else
                {
                    throw new Exception("La categoria no fue encontrada");
                }
            }
            catch (GamaProductoException ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el sistema consulta DBA";
            }

            return Ok(Resultado);
        }

        // DELETE api/<GamaProductoController>/5
        [HttpDelete("Eliminar/{id}")]
        public ActionResult Delete(string gama)
        {
            Respuesta Resultado = new Respuesta();
            Gama_Productos BuscarGama = db.gama_producto.Find(gama);
            try
            {
                if (BuscarGama != null)
                {
                    db.gama_producto.Remove(BuscarGama);
                    db.SaveChanges();
                    Resultado.Info = (new GamaProductosIdViewModel(BuscarGama));
                }
                else
                {
                    throw new Exception("Ctegoria no encontrada");
                }
            }
            catch (Exception)
            {
                Resultado.Mensaje = "error en el sistema";
            }
            return Ok(Resultado);
        }
    }
}
