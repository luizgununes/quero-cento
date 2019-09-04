using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using queroCentoBE.Model.Entities;

namespace queroCentoBE.Models
{
    public class queroCentoBEContext : DbContext
    {
        public queroCentoBEContext (DbContextOptions<queroCentoBEContext> options)
            : base(options)
        {
        }

        public DbSet<queroCentoBE.Model.Entities.Usuario> Usuario { get; set; }
    }
}
