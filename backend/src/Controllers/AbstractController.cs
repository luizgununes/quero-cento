using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using queroCentoBE.Model;
using System.Collections.Generic;
using System.Linq;

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
        /// <param name="predicate"></param>
        /// <returns>O documento especificado da Collection</returns>
        [HttpGet("{id}")]
        public virtual IActionResult Get([FromRoute] string id)
        {
            if (!new ModelStateDictionary().IsValid)
            {
                return new BadRequestResult();
            }

            var obj = Context.Find(x => x.Id == id).FirstOrDefault<T>();

            if (obj == null)
            {
                return new NotFoundResult();
            }

            return new AcceptedResult("Get", obj);
        }
        /// <summary>
        /// Recebe todos os parametros em um formato JSON e insere no documento da Collection
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Documento criado na Collection</returns>
        [HttpPut]
        public virtual T Put(T obj)
        {

            try
            {
                Context.InsertOne(obj);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return obj;
        }
        /// <summary>
        /// Recebe o ID do documento e realiza a atualização na Collection
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="predicate"></param>
        /// <returns>Status:201</returns>
        [HttpPost]
        public virtual IActionResult Post(T obj)
        {
            if (!new ModelStateDictionary().IsValid)
            {
                return new BadRequestResult();
            }
            Context.ReplaceOne(x => x.Id == obj.Id, obj);
            return new CreatedResult("Get", obj);
        }
        /// <summary>
        /// Recebe o ID do documento e deleta o mesmo na Collection
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Status:201</returns>
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(string obj)
        {
            Context.DeleteOne(x => x.Id == obj);

            return new BadRequestResult();
        }


    }
}

