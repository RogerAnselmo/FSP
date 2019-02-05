using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace FSP.Engenharia.API.Controllers
{
    [RoutePrefix("api/Gerenciar-Obra")]
    public class ObraController : ApiController
    {
        private readonly IFSPAppService _fSPAppService;

        public ObraController(IFSPAppService fSPAppService)
        {
            _fSPAppService = fSPAppService;
        }

        [HttpGet]
        [Route("Consultar")]
        public IEnumerable<ObraViewModel> ObterTodasObras()
        {
            return _fSPAppService.ObterTodasObras();
        }
    }
}
