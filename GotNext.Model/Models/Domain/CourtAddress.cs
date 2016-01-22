using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Core.Mapping;
using GotNext.Model.Models.API;

namespace GotNext.Model.Models.Domain
{
   public class CourtAddress : IMapFrom<CourtAddressApi>, IMapTo<CourtAddressApi>
   {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string Country { get; set; }
    }
}
