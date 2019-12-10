using MongoDB.Driver;
using queroCentoBE.Model.Entities;
using System;
namespace queroCentoBE.Model
{
    public class MongoDbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase _database { get; }
        public MongoDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }
        public IMongoCollection<Usuario> Usuario
        {
            get
            {
                return _database.GetCollection<Usuario>("Usuario");
            }
        }
        public IMongoCollection<UsuarioJWT> UsuarioJWT
        {
            get
            {
                return _database.GetCollection<UsuarioJWT>("UsuarioJWT");
            }
        }
        public IMongoCollection<Pedido> Pedido
        {
            get
            {
                return _database.GetCollection<Pedido>("Pedido");
            }
        }
        public IMongoCollection<Anuncio> Anuncio
        {
            get
            {
                return _database.GetCollection<Anuncio>("Anuncio");
            }
        }

    }
}
