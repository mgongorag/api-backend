using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Datos;
using Entidades;

namespace ApiRest
{
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarUsuario")]
        public DataTable agregarUsuario(EntidadUsuarios entidad)
        {
            return DatosUsuario.agregarUsuario(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerUsuarios")]
        public DataTable obtenerUsuarios(EntidadUsuarios entidad)
        {
            return DatosUsuario.obtenerUsuarios(entidad);
        }

        [HttpPost]
        [Route("api/ObtenerDatosUsuario")]
        public DataTable obtenerDatosUsuario(EntidadUsuarios entidad)
        {
            return DatosUsuario.obtenerDatosUsuario(entidad);
        }

        [HttpPost]
        [Route("api/EliminarUsuario")]
        public DataTable eliminarUsuario(EntidadUsuarios entidad)
        {
            return DatosUsuario.eliminarUsuario(entidad);
        }

        [HttpPost]
        [Route("api/ActualizarUsuario")]
        public DataTable ActualizarUsuario(EntidadUsuarios entidad)
        {
            return DatosUsuario.actualizarUsuario(entidad);
        }

        [HttpPost]
        [Route("api/inicioDeSesion")]
        public DataTable inicioDeSesion(EntidadUsuarios entidad)
        {
            return DatosUsuario.inicioDeSesion(entidad);
        }

        [HttpPost]
        [Route("api/MenuUsuario")]
        public DataTable MenuUsuario(EntidadUsuarios entidad)
        {
            return DatosUsuario.MenuUsuario(entidad);
        }

    }
}