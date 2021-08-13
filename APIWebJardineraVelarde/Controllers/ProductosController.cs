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
        Datos db = new Datos();//Conexion a la BD global a la base de datos para todos los metodos
        Respuesta resultado = new Respuesta();

        // GET: api/<ProductosController>
        [HttpGet("Mostrar_todos_los_productos")]
        public ActionResult<string> BuscarTodos()
        {
            Respuesta resultado = new Respuesta();
            try
            {
                List<ProductosIdViewModel> lista = new List<ProductosIdViewModel>();

                foreach (Producto p in db.Producto)
                {
                    lista.Add(new ProductosIdViewModel(p));
                }

                if (lista.Count == 0)
                {
                    throw new Exceptions("No hay Productos para mostrar");
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

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
