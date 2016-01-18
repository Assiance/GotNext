using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotNext.Data.Entities
{
    public class SportType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SportTypeMap : EntityTypeConfiguration<SportType>
    {
        public SportTypeMap()
        {
            ToTable("SportTypes");
            HasKey(t => t.Id);
            Property(t => t.Name).HasMaxLength(30).IsRequired();
        }
    }
}
