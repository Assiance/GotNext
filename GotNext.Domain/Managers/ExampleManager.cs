using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GotNext.Data.Contexts;
using GotNext.Data.Repositories.Interfaces;
using GotNext.Domain.Managers.Interfaces;
using GotNext.Model.Models.Domain;

namespace GotNext.Domain.Managers
{
    public class ExampleManager : IExampleManager
    {
        private readonly IExampleRepository _exampleRepository;

        public IQueryable<Example> Examples
        {
            get
            {
                return _exampleRepository.Examples;
            }
        }

        public ExampleManager(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public Example CreateExample(Example example)
        {
            var created = _exampleRepository.CreateExample(example);

            return created;
        }

        public void UpdateExample(Example example)
        {
            _exampleRepository.UpdateExample(example);
        }

        public void DeleteExample(Example example)
        {
            _exampleRepository.DeleteExample(example);
        }
    }
}
