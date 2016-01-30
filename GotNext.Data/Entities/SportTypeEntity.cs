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
    public class SportTypeEntity : IMapFrom<SportType>, IMapTo<SportType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SportTypeMap : EntityTypeConfiguration<SportTypeEntity>
    {
        public SportTypeMap()
        {
            ToTable("SportTypes");
            HasKey(t => t.Id);
            Property(t => t.Name).HasMaxLength(30).IsRequired();
        }
    }
}
