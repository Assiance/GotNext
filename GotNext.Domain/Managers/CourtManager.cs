using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Data.Repositories.Interfaces;
using GotNext.Domain.Managers.Interfaces;
using GotNext.Model.Models.Domain;

namespace GotNext.Domain.Managers
{
    public class CourtManager : ICourtManager
    {
        private readonly ICourtRepository _courtRepository;

        public IQueryable<Court> Courts
        {
            get
            {
                return _courtRepository.Courts;
            }
        }

        public CourtManager(ICourtRepository courtRepository)
        {
            _courtRepository = courtRepository;
        }

        public Court CreateCourt(Court court)
        {
            var created = _courtRepository.CreateCourt(court);

            return created;
        }

        public void UpdateCourt(Court court)
        {
            _courtRepository.UpdateCourt(court);
        }

        public void DeleteCourts(Court court)
        {
            _courtRepository.DeleteCourt(court);
        }
    }
}
