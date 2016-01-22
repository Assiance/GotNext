using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Model.Models.Domain;

namespace GotNext.Domain.Managers.Interfaces
{
    public interface ICourtManager
    {
        IQueryable<Court> Courts { get; }
        Court CreateCourt(Court court);
        void UpdateCourt(Court court);
        void DeleteCourts(Court court);
    }
}