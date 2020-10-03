using System.Data;
using System.Web.Http;
using Datos;
using Entidades;

namespace ApiRest
{
    public class PuestosController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarPuesto")]
        public DataTable AgregarPuesto(EntidadPuestos entidad)
        {
            return DatosPuestos.AgregarPuesto(entidad);
        }

        [HttpPost]
        [Route("api/ActualizarPuesto")]
        public DataTable ActualizarPuesto(EntidadPuestos entidad)
        {
            return DatosPuestos.ActualizarPuesto(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerPuestos")]
        public DataTable ObtenerPuestos(EntidadPuestos entidad)
        {
            return DatosPuestos.ObtenerPuestos(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerDatosPuesto")]
        public DataTable ObtenerDatosPuesto(EntidadPuestos entidad)
        {
            return DatosPuestos.ObtenerDatosPuesto(entidad);
        }

        [HttpPost]
        [Route("api/EliminarPuesto")]
        public DataTable EliminarPuesto(EntidadPuestos entidad)
        {
            return DatosPuestos.EliminarPuesto(entidad);
        }
    }
}