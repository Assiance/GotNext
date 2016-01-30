using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GotNext.Core.Mapping;
using GotNext.Data.Entities.User;
using GotNext.Model.Models.Domain;

namespace GotNext.Data.Entities
{
    public class PlayerEntity : IMapFrom<Player>, IMapTo<Player>
    {
        public int Id { get; set; }
        public SportTypeEntity SportType { get; set; }
        public ApplicationUserEntity User { get; set; }
    }

    public class PlayerMap : EntityTypeConfiguration<PlayerEntity>
    {
        public PlayerMap()
        {
            ToTable("Players");
            HasKey(t => t.Id);
            HasRequired(x => x.SportType);
            HasRequired(x => x.User);
        }
    }
}
