using MongoDB.Driver;
using queroCentoBE.Model;
using System.Linq;
namespace queroCentoBE.Controllers
{
    public static class Util
    {
        public static bool UsuarioExists(MongoDbContext _context, string id)
        {
            return _context.Usuario.Find(x => x.Id == id).Any();
        }
    }
}
