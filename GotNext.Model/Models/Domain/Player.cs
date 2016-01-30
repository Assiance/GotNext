using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Core.Mapping;
using GotNext.Model.Models.API;

namespace GotNext.Model.Models.Domain
{
    public class Player : IMapFrom<PlayerApi>, IMapTo<PlayerApi>
    {
        public int Id { get; set; }
        public SportType SportType { get; set; }
    }
}
