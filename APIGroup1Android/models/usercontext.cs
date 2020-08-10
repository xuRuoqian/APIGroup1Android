using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGroup1Android.models
{
    public class usercontext : DbContext
    {
        public usercontext(DbContextOptions<usercontext> op) : base(op)
        { }

        public DbSet<user> users;

        public DbSet<APIGroup1Android.models.user> Users { get; set; }
    }
}
