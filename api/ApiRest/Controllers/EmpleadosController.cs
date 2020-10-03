using System.Data;
using System.Web.Http;
using Datos;
using Entidades;

namespace ApiRest.Controllers
{
    public class EmpleadosController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarEmpleado")]
        public DataTable AgregarEmpleado(EntidadEmpleados entidad)
        {
            return DatosEmpleados.AgregarEmpleado(entidad);
        }

        [HttpPost]
        [Route("api/ActualizarEmpleado")]
        public DataTable ActualizarEmpleado(EntidadEmpleados entidad)
        {
            return DatosEmpleados.ActualizarEmpleado(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerEmpleados")]
        public DataTable ObtenerEmpleados(EntidadEmpleados entidad)
        {
            return DatosEmpleados.ObtenerEmpleados(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerDatosEmpleado")]
        public DataTable ObtenerDatosEmpleado(EntidadEmpleados entidad)
        {
            return DatosEmpleados.ObtenerDatosEmpleado(entidad);
        }

        [HttpPost]
        [Route("api/EliminarEmpleado")]
        public DataTable EliminarEmpleado(EntidadEmpleados entidad)
        {
            return DatosEmpleados.EliminarEmpleado(entidad);
        }
    }
}
