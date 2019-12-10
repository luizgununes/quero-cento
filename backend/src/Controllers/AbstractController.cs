using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using queroCentoBE.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace queroCentoBE.Controllers
{
    public abstract class AbstractController<T> where T : IEntidade
    {
        /// <summary>
        /// Instância responsável pelo acesso as Collection's
        /// </summary>
        public virtual IMongoCollection<T> Context { get; }

        /// <summary>
        /// Retorna todos os documentos da Collection 
        /// </summary>
        /// <returns>Todos os documentos da Collection</returns>
        public AbstractController(IMongoCollection<T> context)
        {
            Context = context;
        }
        [HttpGet]
        public virtual IEnumerable<T> Get()
        {
            return Context.Find(m => true).ToList<T>();
        }
        /// <summary>
        /// Retorna todos os documentos contendo o ID especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O documento especificado da Collection</returns>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute] string id)
        {
            var documento = await Context.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (documento == null)
            {
                return new NotFoundResult();
            }

            return new AcceptedResult("Get", documento);
        }
        /// <summary>
        /// Recebe todos os parametros em um formato JSON e insere no documento da Collection
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Documento criado na Collection</returns>
        [HttpPut]
        public virtual async Task<IActionResult> Put(T obj)
        {
            try
            {
                await Context.InsertOneAsync(obj);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return new CreatedResult("Get", obj);
        }
        /// <summary>
        /// Recebe o ID do documento e realiza a atualização na Collection
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Status:201</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post(T obj)
        {
            await Context.ReplaceOneAsync(x => x.Id == obj.Id, obj);

            return new CreatedResult("Get", obj);
        }
        /// <summary>
        /// Recebe o ID do documento e deleta o mesmo na Collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status:201</returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute]string id)
        {
            if (!await Context.Find(x => x.Id == id).AnyAsync())
            {
                return new NotFoundResult();
            }
            await Context.DeleteOneAsync(x => x.Id == id);

            return new AcceptedResult();
        }


    }
}

