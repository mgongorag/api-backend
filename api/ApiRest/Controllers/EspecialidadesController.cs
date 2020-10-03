using System.Data;
using System.Web.Http;
using Datos;
using Entidades;

namespace ApiRest.Controllers
{
    public class EspecialidadesController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarEspecialidad")]
        public DataTable AgregarEspecialidad(EntidadEspecialidades entidad)
        {
            return DatosEspecialidades.AgregarEspecialidad(entidad);
        }

        [HttpPost]
        [Route("api/ActualizarEspecialidad")]
        public DataTable ActualizarEspecialidad(EntidadEspecialidades entidad)
        {
            return DatosEspecialidades.ActualizarEspecialidad(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerEspecialidades")]
        public DataTable ObtenerEspecialidades(EntidadEspecialidades entidad)
        {
            return DatosEspecialidades.ObtenerEspecialidades(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerDatosEspecialidad")]
        public DataTable ObtenerDatosEspecialidad(EntidadEspecialidades entidad)
        {
            return DatosEspecialidades.ObtenerDatosEspecialidad(entidad);
        }

        [HttpPost]
        [Route("api/EliminarEspecialidad")]
        public DataTable EliminarEspecialidad(EntidadEspecialidades entidad)
        {
            return DatosEspecialidades.EliminarEspecialidad(entidad);
        }
    }
}
