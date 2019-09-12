using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using queroCentoBE.Model;
using queroCentoBE.Model.Entities;

namespace queroCentoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly MongoDbContext _context;

        public UsuariosController()
        {
            _context = new MongoDbContext();
        }

        // GET: api/Usuarios
        [Authorize("Bearer")]
        [HttpGet]
        public IEnumerable<Usuario> GetUsuario()
        {
            return _context.Usuario.Find(m => true).ToList<Usuario>();
        }

        // GET: api/Usuarios/5
        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = _context.Usuario.Find(x => x.Id == new ObjectId(id)).FirstOrDefault<Usuario>();

            if (usuario == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario); 
        }

        // PUT: api/Usuarios/
        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Usuario.InsertOne(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

            return NoContent();
        }

        // POST: api/Usuarios
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Usuario.ReplaceOne(x => x.Id == usuario.Id, usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!UsuarioExists(id))
            {
                return NotFound();
            }
            _context.Usuario.DeleteOne(x=>x.Id== new ObjectId(id));
  

            return CreatedAtAction("GetUsuario",null);
        }

        private bool UsuarioExists(string id)
        {
            return _context.Usuario.Find(x=>x.Id == new ObjectId(id)).Any();
        }
    }
}