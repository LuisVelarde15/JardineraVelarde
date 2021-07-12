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
    public class OficinasController : ControllerBase
    {
        Datos db = new Datos();//Conexion a la BD global a la base de datos para todos los metodos
        Respuesta resultado = new Respuesta();

        // GET: api/<OficinasController>
        [HttpGet("Todas las Oficinas")]
        public ActionResult<string> BuscarTodas()
        {
            Respuesta Resultado = new Respuesta();
            try
            {
                List<OficinasIdViewModel> lista = new List<OficinasIdViewModel>();

                foreach (Oficinas o in db.Oficina)
                {
                    lista.Add(new OficinasIdViewModel(o));
                }

                if (lista.Count == 0)
                {
                    throw new OficinaException("No hay Oficinas de productos para mostrar");
                }
                Resultado.Info = lista;
            }
            catch (OficinaException ex)
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

        // GET api/<OficinasController>/5
        [HttpGet("Buscar Oficina")]
        public ActionResult Buscar(string codigo_oficina)
        {
            Oficinas BuscarOficina;
            Respuesta Resultado = new Respuesta();
            try
            {
                BuscarOficina = db.Oficina.Find(codigo_oficina);
                if (BuscarOficina != null)
                {
                    Resultado.Info = new OficinasIdViewModel(BuscarOficina);
                }
                else
                {
                    throw new OficinaException("No se econtro la Oficina solicitada");
                }
            }
            catch (OficinaException ex)
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

        // POST api/<OficinasController>
        [HttpPost("Nueva Oficina")]
        public ActionResult Nuevo([FromBody] OficinasViewModel o)
        {
            Oficinas nueva = new Oficinas(o);
            Respuesta Resultado = new Respuesta();
            try
            {
                db.Oficina.Add(nueva);
                db.SaveChanges();
                Resultado.Info = new OficinasIdViewModel(nueva);
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el sistma consultar al Admnistrador";
            }
            return Ok(Resultado);
        }

        // PUT api/<OficinasController>/5
        [HttpPut("Actualizar Oficina")]
        public ActionResult Put(string Codigo_Oficina, [FromBody] Oficinas o)
        {
            Respuesta Resultado = new Respuesta();
            try
            {
                Oficinas BuscarOficina = db.Oficina.Find(Codigo_Oficina);

                if (BuscarOficina != null)
                {
                    BuscarOficina.Ciudad = o.Ciudad;
                    BuscarOficina.Pais = o.Pais;
                    BuscarOficina.Region = o.Region;
                    BuscarOficina.Codigo_postal = o.Codigo_postal;
                    BuscarOficina.Telefono = o.Telefono;
                    BuscarOficina.Linea_Direccion1 = o.Linea_Direccion1;
                    BuscarOficina.Linea_Direccion2 = o.Linea_Direccion2;

                    db.SaveChanges();
                    Resultado.Info = new OficinasIdViewModel(BuscarOficina);
                }
                else
                {
                    throw new Exception("La Oficina no fue encontrada");
                }
            }
            catch (OficinaException ex)
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

        // DELETE api/<OficinasController>/5
        [HttpDelete("Borrar Oficina")]
        public ActionResult Delete(string Codigo_Oficina)
        {
            Respuesta Resultado = new Respuesta();
            Oficinas BuscarOficina= db.Oficina.Find(Codigo_Oficina);
            try
            {
                if (BuscarOficina != null)
                {
                    db.Oficina.Remove(BuscarOficina);
                    db.SaveChanges();
                    Resultado.Info = (new OficinasIdViewModel(BuscarOficina));
                }
                else
                {
                    throw new Exception("Oficina no encontrada");
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
