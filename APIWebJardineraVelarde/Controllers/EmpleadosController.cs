using APIWebJardineraVelarde.Helpers;
using APIWebJardineraVelarde.Models;
using APIWebJardineraVelarde.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebJardineraVelarde.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        Datos db = new Datos();
        Respuesta resultado = new Respuesta();

        // GET: api/<EmpleadosController>
        [HttpGet("MostrarEmpleados/")]
        public ActionResult Todos()
        {
            Datos db = new Datos();
            Respuesta resultado = new Respuesta();

            var prod = db.Empleado;/*.Include(e => e);*/
            var lista = prod.Select(e => new EmpleadosViewModel
            {
                codigo_empleado = e.codigo_empleado,
                nombre = e.nombre,
                apellido1 = e.apellido1,
                apellido2 = e.apellido2,
                extension = e.extension,
                email = e.email,
                puesto = e.puesto
            }
            );

            resultado.Info = lista;
            return Ok(resultado);
        }

        // GET api/CategoriasporId
        [HttpGet("BuscarEmpleado/")]
        public ActionResult BuscarId(int codigo_empleado)
        {
            try
            {
                Empleado BuscarEmpleado = db.Empleado.Find(codigo_empleado);
                if (BuscarEmpleado != null)
                {

                    resultado.Info = new EmpleadosIdViewModel(BuscarEmpleado);
                }
                else
                {
                    throw new Exceptions("Empleado no encontrada");
                }
            }
            catch (Exceptions ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Error en el sistema, consulte al Administrador";
            }
            return Ok(resultado);

        }

        // POST api/Nuevo
        [HttpPost("Nuevo/")]
        public ActionResult Nuevo([FromBody] EmpleadosViewModel e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Empleado nuevo = new Empleado(e);
                    db.Empleado.Add(nuevo);
                    db.SaveChanges();
                    resultado.Info = new EmpleadosIdViewModel(nuevo);
                }
                else
                {
                    resultado.Estado = false;
                    string MensajeError = "";

                    foreach (var valor in ModelState.Values)
                    {
                        MensajeError += valor.Errors[0].ErrorMessage;
                        MensajeError += " | ";
                    }
                    resultado.Mensaje = MensajeError; ;
                }
            }

            catch (Exception)
            {
                resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(resultado);
        }


        // PUT api/Actualizar/id
        [HttpPut("Actualizar/{id}")]
        public ActionResult Actualizar(int id, [FromBody] EmpleadosViewModel e)
        {

            try
            {
                Empleado BuscarEmpleado = db.Empleado.Find(id);

                if (BuscarEmpleado != null)
                {
                    BuscarEmpleado.nombre = e.nombre;
                    BuscarEmpleado.apellido1 = e.apellido1;
                    BuscarEmpleado.apellido2 = e.apellido2;
                    BuscarEmpleado.extension = e.extension;
                    BuscarEmpleado.email = e.email;
                    BuscarEmpleado.codigo_oficina = e.codigo_oficina;
                    BuscarEmpleado.codigo_jefe = e.codigo_jefe;
                    BuscarEmpleado.puesto = e.puesto;
                    db.SaveChanges();
                    resultado.Info = new EmpleadosIdViewModel(BuscarEmpleado);

                }
                else
                    throw new Exception("Empleado no encontrado");
            }
            catch (Exceptions ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }
            return Ok(resultado);
        }

        // DELETE api/Eliminar/id
        [HttpDelete("Eliminar/{id}")]
        public ActionResult Eliminar(int id)
        {
            try
            {
                Empleado BuscarEmpleado = db.Empleado.Find(id);
                if (BuscarEmpleado != null)
                {
                    db.Empleado.Remove(BuscarEmpleado);
                    db.SaveChanges();
                    resultado.Info = new
                            EmpleadosViewModel(BuscarEmpleado);

                }
                else
                    throw new Exception("El Empleado no fue encontrado");
            }
            catch (Exceptions ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }
            return Ok(resultado);
        }
    }
}

