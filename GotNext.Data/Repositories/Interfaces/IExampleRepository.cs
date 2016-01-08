using System.Linq;
using GotNext.Model.Models.Domain;

namespace GotNext.Data.Repositories.Interfaces
{
    public interface IExampleRepository
    {
        IQueryable<Example> Examples { get; }

        Example CreateExample(Example example);
        void UpdateExample(Example example);
        void DeleteExample(Example example);
    }
}
