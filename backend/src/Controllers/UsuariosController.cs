using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using queroCentoBE.Model;
using queroCentoBE.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace queroCentoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly MongoDbContext _context;

        public MongoDbContext Context => _context;

        public UsuariosController()
        {
            _context = new MongoDbContext();
        }

        // GET: api/Usuarios
        /// <summary>
        /// Retorna todos os usuários cadastrados
        /// </summary>
        /// <returns></returns>
        //[Authorize("Bearer")]
        [HttpGet]
        public IEnumerable<Usuario> GetUsuario()
        {
            return Context.Usuario.Find(m => true).ToList<Usuario>();
        }
        /// <summary>
        /// Retorna o usuário especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Usuarios/5
        //[Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = Context.Usuario.Find(x => x.Id == id).FirstOrDefault<Usuario>();

            if (usuario == null)
            {
                return NotFound();
            }

            return AcceptedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }
        /// <summary>
        /// Cadastra o usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        // PUT: api/Usuarios/
        //[Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> PutUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Context.Usuario.InsertOne(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }
        /// <summary>
        /// Atualiza o usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        // POST: api/Usuarios
        //[Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.Usuario.ReplaceOne(x => x.Id == usuario.Id, usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }
        /// <summary>
        /// Deleta o usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Usuarios/5
        //[Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!Util.UsuarioExists(Context, id))
            {
                return NotFound();
            }
            Context.Usuario.DeleteOne(x => x.Id == id);

            return AcceptedAtAction("GetUsuario", null);
        }


    }
}