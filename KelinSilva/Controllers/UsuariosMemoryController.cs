using Dto.Usuario;
using Service.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class UsuariosMemoryController : ApiController
    {


        // GET: api/Usuarios
        public IQueryable<UsuarioDto> GetUsuarios()
        {
            return new UsuarioService().GetUsuariosMemoria().AsQueryable();
        }

        // GET: api/UsuariosMemory/5
        [ResponseType(typeof(UsuarioDto))]
        public IHttpActionResult GetUsuario(int id)
        {
            var usuario = new UsuarioService().GetUsuarioIdMemoria(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/UsuariosMemory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, UsuarioDto usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.Id)
            {
                return BadRequest();
            }

            new UsuarioService().UpdateUsuarioMemoria(usuario);

            return Ok(usuario);
        }

        // POST: api/UsuariosMemory
        [ResponseType(typeof(UsuarioDto))]
        public IHttpActionResult PostUsuario(UsuarioDto usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuario.Id = new UsuarioService().SaveUsuarioMemoria(usuario);

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/UsuariosMemory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteUsuario(int id)
        {

            if (new UsuarioService().DeleteUsuarioMemoria(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

    }
}
