using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models.DbContexts
{
    public class CapsuleerDbContext : DbContext
    {
        public DbSet<Capsuleer> Capsuleers { get; set; }
    }
}