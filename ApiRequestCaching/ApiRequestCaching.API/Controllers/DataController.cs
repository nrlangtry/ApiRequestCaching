using ApiRequestCaching.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiRequestCaching.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DataController : Controller
    {
        readonly DataRepositoryResolver DataRepositoryResolver;

        public DataController(DataRepositoryResolver dataRepositoryResolver)
        {
            DataRepositoryResolver = dataRepositoryResolver;
        }

        // GET api/<controller>/<action>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var repository = DataRepositoryResolver(null);

            var results = repository.GetData(id);

            return new JsonResult(results);
        }

        // GET api/<controller>/<action>/5
        [HttpGet("{id}")]
        public JsonResult GetCached(int id)
        {
            var repository = DataRepositoryResolver("Cache");

            var results = repository.GetData(id);

            return new JsonResult(results);
        }

        // GET api/<controller>/<action>/5
        [HttpGet("{id}")]
        public JsonResult GetCachedTwice(int id)
        {
            var repository = DataRepositoryResolver("Cache");

            var resultList = new List<string>();

            // once
            var results = repository.GetData(id);
            resultList.AddRange(results);

            // twice
            var sameResults = repository.GetData(id);
            resultList.AddRange(sameResults);

            return new JsonResult(results);
        }

        // GET api/<controller>/<action>/5
        [HttpGet("{id}")]
        public JsonResult GETStaticCached(int id)
        {
            var repository = DataRepositoryResolver("Static Cache");

            var results = repository.GetData(id);

            return new JsonResult(results);
        }
    }
}
