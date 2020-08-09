using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGroup1Android.models
{
    public class Agentcontext : DbContext
    {
        public Agentcontext(DbContextOptions<Agentcontext> op) : base(op)
        { }

        public DbSet<Agentdetial> agentdetials;

        public DbSet<APIGroup1Android.models.Agentdetial> Agentdetials { get; set; }
    }
}
