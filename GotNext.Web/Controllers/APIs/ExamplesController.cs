using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GotNext.Domain.Managers.Interfaces;
using GotNext.Domain.Services.Interfaces;
using GotNext.Model.Models.API;
using GotNext.Model.Models.Domain;

namespace GotNext.Web.Controllers.APIs
{
    public class ExamplesController : ApiController
    {
        private readonly IExampleManager _exampleManager;

        public ExamplesController(IExampleManager exampleManager)
        {
            _exampleManager = exampleManager;
        }

        // GET: api/Examples
        public IQueryable<ExampleApi> GetExamples()
        {
            return _exampleManager.Examples.ProjectTo<ExampleApi>();
        }

        // GET: api/Examples/5
        [ResponseType(typeof(ExampleApi))]
        public IHttpActionResult GetExample(int id)
        {
            Example example = _exampleManager.Examples.FirstOrDefault(x => x.Id == id);
            if (example == null)
            {
                return NotFound();
            }

            var apiExample = Mapper.Map<ExampleApi>(example);

            return Ok(apiExample);
        }

        // PUT: api/Examples/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExample(int id, Example example)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != example.Id)
            {
                return BadRequest();
            }

            try
            {
                _exampleManager.UpdateExample(example);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExampleExists(id))
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

        // POST: api/Examples
        [ResponseType(typeof(ExampleApi))]
        public IHttpActionResult PostExample(Example example)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            example = _exampleManager.CreateExample(example);

            var apiExample = Mapper.Map<ExampleApi>(example);

            return CreatedAtRoute("DefaultApi", new { id = example.Id }, apiExample);
        }

        // DELETE: api/Examples/5
        [ResponseType(typeof(ExampleApi))]
        public IHttpActionResult DeleteExample(int id)
        {
            Example example = _exampleManager.Examples.FirstOrDefault(x => x.Id == id);
            if (example == null)
            {
                return NotFound();
            }

            _exampleManager.DeleteExample(example);

            return Ok(example);
        }

        private bool ExampleExists(int id)
        {
            return _exampleManager.Examples.Count(e => e.Id == id) > 0;
        }
    }
}