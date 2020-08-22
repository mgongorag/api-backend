using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest
{
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarUsuario")]
        public DataTable agregarUsuario(Entidades.EntidadUsuarios entidad)
        {
            return Datos.DatosUsuario.agregarUsuario(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerUsuarios")]
        public DataTable obtenerUsuarios()
        {
            return Datos.DatosUsuario.obtenerUsuarios();
        }

        [HttpPost]
        [Route("api/ObtenerDatosUsuario")]
        public DataTable obtenerDatosUsuario(Entidades.EntidadUsuarios entidad)
        {
            return Datos.DatosUsuario.obtenerDatosUsuario(entidad);
        }

        [HttpPost]
        [Route("api/EliminarUsuario")]
        public DataTable eliminarUsuario(Entidades.EntidadUsuarios entidad)
        {
            return Datos.DatosUsuario.eliminarUsuario(entidad);
        }

        [HttpPost]
        [Route("api/ActualizarUsuario")]
        public DataTable ActualizarUsuario(Entidades.EntidadUsuarios entidad)
        {
            return Datos.DatosUsuario.actualizarUsuario(entidad);
        }

    }
}