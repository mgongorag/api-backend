using System.Data;
using System.Web.Http;
using Datos;
using Entidades;

namespace ApiRest
{
    public class ServiciosController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarServicio")]
        public DataTable AgregarServicio(EntidadServicios entidad)
        {
            return DatosServicios.AgregarServicio(entidad);
        }

        [HttpPost]
        [Route("api/ActualizarServicio")]
        public DataTable ActualizarServicio(EntidadServicios entidad)
        {
            return DatosServicios.ActualizarServicio(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerServicios")]
        public DataTable ObtenerServicios(EntidadServicios entidad)
        {
            return DatosServicios.ObtenerServicios(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerDatosServicio")]
        public DataTable ObtenerDatosServicio(EntidadServicios entidad)
        {
            return DatosServicios.ObtenerDatosServicio(entidad);
        }

        [HttpPost]
        [Route("api/EliminarServicio")]
        public DataTable EliminarServicio(EntidadServicios entidad)
        {
            return DatosServicios.EliminarServicio(entidad);
        }
    }
}
