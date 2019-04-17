using Rehber.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Entities.Mapping
{
    class AdresMapping : EntityTypeConfiguration<Adres>
    {
        public AdresMapping()
        {
            Property(x => x.Il).HasMaxLength(20).IsRequired();
            Property(x => x.Ilce).HasMaxLength(20).IsRequired();
        }
    }
}
