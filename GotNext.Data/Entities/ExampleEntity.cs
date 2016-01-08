using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using GotNext.Core.Mapping;
using GotNext.Model.Models.Domain;

namespace GotNext.Data.Entities
{
    public class ExampleEntity : IMapFrom<Example>, IMapTo<Example>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ExampleMap : EntityTypeConfiguration<ExampleEntity>
    {
        public ExampleMap()
        {
            ToTable("Examples");
            HasKey(t => t.Id);
            Property(t => t.FirstName).HasMaxLength(25).IsRequired();
            Property(t => t.LastName).HasMaxLength(25).IsRequired();
        }
    }
}