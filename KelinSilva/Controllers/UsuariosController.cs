using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Data.Context;
using Data.Models;
using Dto.Usuario;
using Service.Usuario;

namespace WebApi.Controllers
{
    public class UsuariosController : ApiController
    {
        

        // GET: api/Usuarios
        public IQueryable<UsuarioDto> GetUsuarios()
        {
            return new UsuarioService().GetUsuarios().AsQueryable();
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(UsuarioDto))]
        public IHttpActionResult GetUsuario(int id)
        {
            var usuario = new UsuarioService().GetUsuarioId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
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

            new UsuarioService().UpdateUsuario(usuario);

            return Ok(usuario);
        }

        // POST: api/Usuarios
        [ResponseType(typeof(UsuarioDto))]
        public IHttpActionResult PostUsuario(UsuarioDto usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           usuario.Id = new UsuarioService().SaveUsuario(usuario);

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            
            if (new UsuarioService().DeleteUsuario(id))
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