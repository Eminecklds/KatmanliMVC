using Rehber.Entities.Entities;
using Rehber.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Entities.Context
{
    public class RehberDbContext:DbContext
    {
        public RehberDbContext() : base("RehberConnectionString")
        {

        }
        public DbSet<Kisi> Kisis { get; set; }
        public DbSet<Adres> Adres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KisiMapping());
            modelBuilder.Configurations.Add(new AdresMapping());
        }
    }
}
