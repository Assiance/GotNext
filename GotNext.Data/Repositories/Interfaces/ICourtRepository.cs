using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Model.Models.Domain;

namespace GotNext.Data.Repositories.Interfaces
{
    public interface ICourtRepository
    {
        IQueryable<Court> Courts { get; }

        Court CreateCourt(Court court);
        void UpdateCourt(Court court);
        void DeleteCourt(Court court);
    }
}
