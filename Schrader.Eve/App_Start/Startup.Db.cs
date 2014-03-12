using Schrader.Eve.Models.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schrader.Eve
{
    public partial class Startup
    {
        private void ConfigureDatabase()
        {
            Database.SetInitializer<MissionDbContext>(null);
        }
    }
}