using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using queroCentoBE.Model;
using queroCentoBE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace queroCentoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnunciosController : AbstractController<Anuncio>
    {
        public AnunciosController() : base(new MongoDbContext().Anuncio)
        {
        }
    }
}
