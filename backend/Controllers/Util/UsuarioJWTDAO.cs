using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using queroCentoBE.Model;
using queroCentoBE.Model.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace queroCentoBE.Util
{
    public class UsuarioJWTDAO
    {
        private readonly MongoDbContext _context;

        private IConfiguration _configuration;

        public UsuarioJWTDAO(IConfiguration configuration)
        {
            _context = new MongoDbContext();
            _configuration = configuration;
        }

        public UsuarioJWT Find(string userID)
        {
            return _context.UsuarioJWT.Find(x => x.UserID == userID).FirstOrDefault<UsuarioJWT>();
        }
    }

    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}