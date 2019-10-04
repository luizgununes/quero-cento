using queroCentoBE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace queroCentoBE.Controllers
{
    public class Util
    {
        public static bool UsuarioExists(MongoDbContext _context,string id)
        {
            return _context.Usuario.Find(x => x.Id == new ObjectId(id)).Any();
        }
    }
}
