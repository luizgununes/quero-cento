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
    public class UsuariosController : AbstractController<Usuario>
    {
        public UsuariosController() : base(new MongoDbContext().Usuario)
        {
        }
        /// <summary>
        /// Encontra o usuario e retorna o documento
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>O documento especificado da Collection</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Login([FromBody]  Usuario usuario)
        {
            var documento = await Context.Find(x => x.Id == usuario.Id && x.Password == usuario.Password).FirstOrDefaultAsync();

            if (documento == null)
            {
                return new NotFoundResult();
            }

            return new AcceptedResult("Get", documento);
        }
    }
}