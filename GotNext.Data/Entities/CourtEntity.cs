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
    public class CourtEntity : IMapFrom<Court>, IMapTo<Court>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CourtAddressEntity Address { get; set; }
        public decimal Price { get; set; }
        public bool IsOutDoor { get; set; }
        public string PaymentType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class CourtMap : EntityTypeConfiguration<CourtEntity>
    {
        public CourtMap()
        {
            ToTable("Courts");
            HasKey(t => t.Id);
            Property(t => t.Name).HasMaxLength(25).IsRequired();
            HasRequired(t => t.Address);
            Property(t => t.Price).IsRequired();
            Property(t => t.IsOutDoor).IsRequired();
            Property(t => t.PaymentType).IsRequired();
            Property(t => t.Latitude).IsRequired();
            Property(t => t.Longitude).IsRequired();
        }
    }
}