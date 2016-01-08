using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GotNext.Data.Contexts;
using GotNext.Data.Entities;
using GotNext.Data.Repositories.Interfaces;
using GotNext.Model.Models.Domain;

namespace GotNext.Data.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly IDataContext _dataContext;

        public IQueryable<Example> Examples
        {
            get
            {
                return _dataContext.GetQueryable<ExampleEntity>().ProjectTo<Example>();
            }
        }

        public ExampleRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Example CreateExample(Example example)
        {
            var exampleEntity = Mapper.Map<ExampleEntity>(example);

            try
            {
                _dataContext.Upsert(exampleEntity);
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(exampleEntity));
            }

            return example;
        }

        public void UpdateExample(Example example)
        {
            var exampleEntity = Mapper.Map<ExampleEntity>(example);

            try
            {
                _dataContext.Upsert(exampleEntity);
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(exampleEntity));
            }
        }

        public void DeleteExample(Example example)
        {
            var exampleEntity = Mapper.Map<ExampleEntity>(example);

            try
            {
                _dataContext.Remove(exampleEntity);
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(exampleEntity));
            }
        }
    }
}
