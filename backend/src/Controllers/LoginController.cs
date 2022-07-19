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
    public class LoginController 
    {
        /// <summary>
        /// Instância responsável pelo acesso as Collection's
        /// </summary>
        public virtual IMongoCollection<Usuario> Context { get; }

        /// <summary>
        /// Retorna todos os documentos da Collection 
        /// </summary>
        /// <returns>Todos os documentos da Collection</returns>
        public LoginController(IMongoCollection<Usuario> context)
        {
            Context = context;
        }
        /// <summary>
        /// Encontra o usuario e retorna o documento
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>O documento especificado da Collection</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Login(Usuario usuario)
        {
            var documento = await Context.Find(x => x.Username == usuario.Username && x.Password == usuario.Password).FirstOrDefaultAsync();

            if (documento == null)
            {
                return new NotFoundResult();
            }

            return new AcceptedResult("Post", documento);
        }

    }
}