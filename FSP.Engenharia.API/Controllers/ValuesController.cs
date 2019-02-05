using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace FSP.Engenharia.API.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IFSPAppService _fSPAppService;

        public ValuesController(IFSPAppService fSPAppService)
        {
            _fSPAppService = fSPAppService;
        }

        //[HttpGet]
        public IEnumerable<ObraViewModel> Get()
        {
            return _fSPAppService.ObterTodasObras();
        }

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
