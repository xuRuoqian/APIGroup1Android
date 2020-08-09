using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGroup1Android.models
{
    public class Housecontext : DbContext
    {

        public Housecontext(DbContextOptions<Housecontext> op) : base(op)
        { }

        public DbSet<House> houses;

        public DbSet<APIGroup1Android.models.House> Houses { get; set; }

    }
}
