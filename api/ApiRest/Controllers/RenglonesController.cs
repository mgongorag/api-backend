using System.Data;
using System.Web.Http;
using Datos;
using Entidades;

namespace ApiRest
{
    public class RenglonesController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarRenglon")]
        public DataTable AgregarRenglon(EntidadRenglones entidad)
        {
            return DatosRenglones.AgregarRenglon(entidad);
        }

        [HttpPost]
        [Route("api/ActualizarRenglon")]
        public DataTable ActualizarRenglon(EntidadRenglones entidad)
        {
            return DatosRenglones.ActualizarRenglon(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerRenglones")]
        public DataTable ObtenerRenglones(EntidadRenglones entidad)
        {
            return DatosRenglones.ObtenerRenglones(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerDatosRenglon")]
        public DataTable ObtenerDatosRenglon(EntidadRenglones entidad)
        {
            return DatosRenglones.ObtenerDatosRenglon(entidad);
        }

        [HttpPost]
        [Route("api/EliminarRenglon")]
        public DataTable EliminarRenglon(EntidadRenglones entidad)
        {
            return DatosRenglones.EliminarRenglon(entidad);
        }
    }
}
