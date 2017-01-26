using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using TNetWebApi.Respository;

namespace TNetWebApi.Controllers
{
    public class StationsController : ApiController
    {
        static StationsRepository repository;

         static StationsController()
        {
            repository = new StationsRepository();
        }

        // GET api/values
        [SwaggerOperation("GetAll")]
        public IEnumerable<Station> Get()
        {
            return repository.GetStations();
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public Station Get(int id)
        {
            return repository.GetStationByID(id);
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]string value)
        {
            repository.AddStation(value);
        }

        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Put(int id, [FromBody]string value)
        {
            repository.UpdateStation(id, value);
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(int id)
        {
            repository.RemoveStation(id);
        }
    }
}
