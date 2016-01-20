using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Core.Mapping;
using GotNext.Model.Models.Domain;

namespace GotNext.Data.Entities
{
    public class CourtAddressEntity : IMapFrom<CourtAddress>, IMapTo<CourtAddress>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string Country { get; set; }

        public class AddressMap : EntityTypeConfiguration<CourtAddressEntity>
        {
            public AddressMap()
            {
                ToTable("CourtAddresses");
                HasKey(t => t.Id);
                Property(t => t.City).HasMaxLength(30).IsRequired();
                Property(t => t.State).HasMaxLength(30).IsRequired();
                Property(t => t.ZipCode).HasMaxLength(10).IsRequired();
                Property(t => t.StreetLine1).IsRequired();
                Property(t => t.StreetLine2);
                Property(t => t.Country).HasMaxLength(30).IsRequired();
            }
        }
    }
}
