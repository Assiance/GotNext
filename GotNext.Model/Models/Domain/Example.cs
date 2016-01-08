using GotNext.Core.Mapping;
using GotNext.Model.Models.API;

namespace GotNext.Model.Models.Domain
{
    public class Example : IMapFrom<ExampleApi>, IMapTo<ExampleApi>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
