using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GotNext.Domain.Managers.Interfaces;
using GotNext.Model.Models.API;
using GotNext.Model.Models.Domain;
using GotNext.Web.ViewModels;

namespace GotNext.Web.Controllers.APIs
{
    public class CourtsController : ApiController
    {
        private readonly ICourtManager _courtManager;

        public CourtsController(ICourtManager courtManager)
        {
            _courtManager = courtManager;            
        }

        public IQueryable<CourtAPi> GetCourts()
        {
            return _courtManager.Courts.ProjectTo<CourtAPi>();
        }

        [ResponseType(typeof(CourtAPi))]
        public IHttpActionResult GetCourt(int id)
        {
            Court court = _courtManager.Courts.FirstOrDefault(x => x.Id == id);
            if (court == null)
            {
                return NotFound();
            }

            var apiCourt = Mapper.Map<CourtAPi>(court);

            return Ok(apiCourt);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourt(int id, Court court)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != court.Id)
            {
                return BadRequest();
            }

            try
            {
                _courtManager.UpdateCourt(court);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourtExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(CourtAPi))]
        public IHttpActionResult PostCourt(CreateCourtRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var court = _courtManager.CreateCourt(Mapper.Map<Court>(request));

            var apiCourt = Mapper.Map<CourtAPi>(court);

            return CreatedAtRoute("DefaultApi", new { id = court.Id }, apiCourt);
        }

        [ResponseType(typeof(CourtAPi))]
        public IHttpActionResult DeleteCourt(int id)
        {
           Court court = _courtManager.Courts.FirstOrDefault(x => x.Id == id);
            if (court == null)
            {
                return NotFound();
            }

            _courtManager.DeleteCourts(court);

            return Ok(court);
        }

        private bool CourtExists(int id)
        {
            return _courtManager.Courts.Count(e => e.Id == id) > 0;
        }
    }
}