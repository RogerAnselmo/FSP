using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engenharia.UI.Site.Help;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace FSP.Engenharia.UI.Site.Controllers
{
    [RoutePrefix("Gerenciar-Obra")]
    public class ObraController : Controller
    {
        private readonly IFSPAppService _fSPAppService;

        public ObraController(IFSPAppService fSPAppService)
        {
            _fSPAppService = fSPAppService;
        }

        [Route("Consultar")]
        public ActionResult Consulta()
        {
            return View();
        }
        // GET: Obras
        [Route("Cadastrar")]
        public ActionResult Cadastro()
        {
            ObterStatusObra();
            ObterEstados();
            return View(new ObraViewModel { CodigoObra = 0, DescricaoObjeto = string.Empty, NomeObra = string.Empty });
        }
        // GET: Obras
        [Route("Alterar/{id:int}")]
        public ActionResult Alteracao(int id)
        {
            ObterStatusObra();
            ObterEstados();
            return View(_fSPAppService.ObterObraPorId(id));
        }

        #region Seção: Inclusão
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Salvar-Obra")]
        public ActionResult Salvar(ObraViewModel model)
        {
            if (ModelState.IsValid)
            {
                var obraViewModel = _fSPAppService.RegistrarInclusaoObra(model);

                if (!obraViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in obraViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
                }
                return Json(new { erro = 0, mensagem = obraViewModel.ValidationResult.Message });
            }
            else
                return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
        }
        #endregion

        #region Seção: Alteração
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Alterar-Obra")]
        public ActionResult Alterar(ObraViewModel model)
        {
            if (ModelState.IsValid)
            {
                var obraViewModel = _fSPAppService.RegistrarAlteracaoObra(model);

                if (!obraViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in obraViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
                }

                return Json(new { erro = 1, mensagem = obraViewModel.ValidationResult.Message });
            }
            else
                return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
        }
        #endregion

        #region Seção: Exclusão
        [HttpGet]
        [Route("Excluir-Obra/{id:int}")]
        public ActionResult Excluir(int id)
        {
            var obraViewModel = _fSPAppService.RegistrarExclusaoObra(id);
            return Json(new { erro = 2, mensagem = "Registro excluído com sucesso." }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpGet]
        [Route("ObterObras")]
        public string ObterTodasObras()
        {
            return JsonConvert.SerializeObject(new { data = _fSPAppService.ObterTodasObras() });
        }

        [HttpPost]
        [Route("ObterObrasPorDescricao")]
        public string ObterObrasPorDescricao(string nomeObra)
        {
            return JsonConvert.SerializeObject(new { data = _fSPAppService.ObterObraPorDescricao(nomeObra) });
        }

        private void ObterStatusObra()
        {
            var statusObrasViewModel = _fSPAppService.ObterStatusObras();
            ViewBag.StatusObra = string.Empty;
            ViewBag.StatusObra = new SelectList(statusObrasViewModel, "Descricao", "Descricao", "0");
        }
        private void ObterEstados()
        {
            var estadoViewModel = _fSPAppService.ObterEstados();
            ViewBag.Estados = string.Empty;
            ViewBag.Estados = new SelectList(estadoViewModel, "Sigla", "Nome", "0");
        }
    }
}