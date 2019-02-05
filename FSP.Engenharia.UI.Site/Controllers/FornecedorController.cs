using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engenharia.UI.Site.Help;
using Newtonsoft.Json;
using System.Web.Mvc;
using System;

namespace FSP.Engenharia.UI.Site.Controllers
{
    [RoutePrefix("Gerenciar-Fornecedor")]
    public class FornecedorController : Controller
    {
        private readonly IFSPAppService _fSPAppService;

        public FornecedorController(IFSPAppService fSPAppService)
        {
            _fSPAppService = fSPAppService;
        }

        [Route("Consultar")]
        public ActionResult Consulta()
        {
            return View();
        }
        // GET: Fornecedors
        [Route("Cadastrar")]
        public ActionResult Cadastro()
        {
            ObterEstados();
            return View(new FornecedorViewModel { CodigoFornecedor = 0, RazaoSocial = string.Empty });
        }
        // GET: Fornecedors
        [Route("Alterar/{id:int}")]
        public ActionResult Alteracao(int id)
        {
            ObterEstados();
            return View(_fSPAppService.ObterFornecedorPorId(id));
        }

        #region Seção: Inclusão
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Salvar-Fornecedor")]
        public ActionResult Salvar(FornecedorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var FornecedorViewModel = _fSPAppService.RegistrarInclusaoFornecedor(model);

                if (!FornecedorViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in FornecedorViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
                }
                return Json(new { erro = 0, mensagem = FornecedorViewModel.ValidationResult.Message });
            }
            else
                return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
        }
        #endregion

        #region Seção: Alteração
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Alterar-Fornecedor")]
        public ActionResult Alterar(FornecedorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var FornecedorViewModel = _fSPAppService.RegistrarAlteracaoFornecedor(model);

                if (!FornecedorViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in FornecedorViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
                }

                return Json(new { erro = 1, mensagem = FornecedorViewModel.ValidationResult.Message });
            }
            else
                return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
        }
        #endregion

        #region Seção: Exclusão
        [HttpGet]
        [Route("Excluir-Fornecedor/{id:int}")]
        public ActionResult Excluir(int id)
        {
            var FornecedorViewModel = _fSPAppService.RegistrarExclusaoFornecedor(id);
            return Json(new { erro = 2, mensagem = "Registro excluído com sucesso." }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpGet]
        [Route("ObterFornecedores")]
        public string ObterTodosFornecedors()
        {
            return JsonConvert.SerializeObject(new { data = _fSPAppService.ObterTodosFornecedors() });
        }

        private void ObterEstados()
        {
            var estadoViewModel = _fSPAppService.ObterEstados();
            ViewBag.Estados = string.Empty;
            ViewBag.Estados = new SelectList(estadoViewModel, "Sigla", "Nome", "0");
        }

    }
}