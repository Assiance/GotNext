using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotNext.Data.Entities
{
    public class CourtAddressEntity
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string Country { get; set; }

        public CourtAddressEntity(string city, string state, string zipCode, string streetLine1, string streetLine2, string country)
        {
            City = city;
            State = state;
            ZipCode = zipCode;
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            Country = country;

        }

        public class AddressMap : EntityTypeConfiguration<CourtAddressEntity>
        {
            public AddressMap()
            {
                ToTable("Addresses");
                HasKey(t => t.Id);
                Property(t => t.City).IsRequired();
                Property(t => t.State).IsRequired();
                Property(t => t.ZipCode).IsRequired();
                Property(t => t.StreetLine1).IsRequired();
                Property(t => t.StreetLine1).IsRequired();
                Property(t => t.StreetLine2).IsRequired();
                Property(t => t.Country).IsRequired();
            }
        }
    }
}
