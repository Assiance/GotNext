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
using StructureMap.Building;

namespace GotNext.Data.Repositories
{
   public class CourtRepository : ICourtRepository
    {
        private readonly IDataContext _dataContext;

        public IQueryable<Court> Courts
        {
            get
            {
                return _dataContext.GetQueryable<CourtEntity>().ProjectTo<Court>();
            }
        }

        public CourtRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Court CreateCourt(Court court)
        {
            var courtEntity = Mapper.Map<CourtEntity>(court);
            try
            {
                _dataContext.Upsert(courtEntity);
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(courtEntity));
            }

            return court;
        }

        public void UpdateCourt(Court court)
        {
            var courtEntity = Mapper.Map<CourtEntity>(court);

            try
            {
                _dataContext.Upsert(courtEntity);
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(courtEntity));
            }
        }

        public void DeleteCourt(Court court)
        {
            var courtEntity = Mapper.Map<CourtEntity>(court);

            try
            {
                _dataContext.Remove(courtEntity);
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(courtEntity));
            }
        }
    }
}
