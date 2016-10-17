using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular2AspNetCore
{
    public class GotContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }

        public GotContext(DbContextOptions options) : base(options)
        {

        }
    }
}
