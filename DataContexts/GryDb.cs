using Find_a_Game.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Find_a_Game.DataContexts
{
    public class GryDb : DbContext
    {
        public DbSet<Gra> Gry { get; set; }
    }
}