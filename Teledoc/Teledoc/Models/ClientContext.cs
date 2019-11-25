using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Teledoc.Models
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }
    }
}