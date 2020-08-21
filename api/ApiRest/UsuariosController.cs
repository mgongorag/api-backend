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
        public DataTable agregarUsuario(Entidades.Usuarios entidad)
        {
            return Datos.Usuarios.agregarUsuario(entidad);
        }
    }
}