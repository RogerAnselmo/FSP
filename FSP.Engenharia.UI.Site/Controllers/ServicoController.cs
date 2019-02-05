using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engenharia.UI.Site.Help;
using Newtonsoft.Json;
using System.Web.Mvc;
using System;

namespace FSP.Engenharia.UI.Site.Controllers
{
    [RoutePrefix("Gerenciar-Servico")]
    public class ServicoController : Controller
    {
        private readonly IFSPAppService _fspAppService;

        public ServicoController(IFSPAppService fspAppService)
        {
            _fspAppService = fspAppService;
        }

        [Route("Consultar")]
        public ActionResult Consulta()
        {
            return View();
        }
        // GET: Servicos
        [Route("Cadastrar")]
        public ActionResult Cadastro()
        {
            return View(new ServicoViewModel { CodigoServico=0, Percentual = Convert.ToDecimal("0,00"), Valor = Convert.ToDecimal("0,00") });
        }
        // GET: Servicos
        [Route("Alterar/{id:int}")]
        public ActionResult Alteracao(int id)
        {
            return View(_fspAppService.ObterServicoPorId(id));
        }

        #region Seção: Inclusão
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Salvar-Servico")]
        public ActionResult Salvar(ServicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ServicoViewModel = _fspAppService.RegistrarInclusaoServico(model);

                if (!ServicoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in ServicoViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
                }
                return Json(new { erro = 0, mensagem = ServicoViewModel.ValidationResult.Message });
            }
            else
                return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
        }
        #endregion

        #region Seção: Alteração
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Alterar-Servico")]
        public ActionResult Alterar(ServicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ServicoViewModel = _fspAppService.RegistrarAlteracaoServico(model);

                if (!ServicoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in ServicoViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
                }

                return Json(new { erro = 1, mensagem = ServicoViewModel.ValidationResult.Message });
            }
            else
                return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
        }
        #endregion

        #region Seção: Exclusão
        [HttpGet]
        [Route("Excluir-Servico/{id:int}")]
        public ActionResult Excluir(int id)
        {
            var ServicoViewModel = _fspAppService.RegistrarExclusaoServico(id);
            return Json(new { erro = 2, mensagem = "Registro excluído com sucesso." }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpGet]
        [Route("ObterServicos")]
        public string ObterTodosServicos()
        {
            return JsonConvert.SerializeObject(new { data = _fspAppService.ObterTodosServicos() });
        }
        [HttpGet]
        [Route("Obter-Servico-Da-Obra-Relacionados-Na-Itenizacao/{id:int}")]
        public string ObterServicoDaObraRelacionadosNaItenizacao(int id)
        {
            return JsonConvert.SerializeObject(new { data = _fspAppService.ObterServicoDaObraRelacionadosNaItemServico(id) });
        }
    }
}