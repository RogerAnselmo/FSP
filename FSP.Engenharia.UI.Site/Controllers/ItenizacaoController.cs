using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engenharia.UI.Site.Help;
using Newtonsoft.Json;
using System.Web.Mvc;
using System;

namespace FSP.Engenharia.UI.Site.Controllers
{
    [RoutePrefix("Gerenciar-Itenizacao")]
    public class ItenizacaoController : Controller
    {
        private readonly IFSPAppService _fSPAppService;

        public ItenizacaoController(IFSPAppService fSPAppService)
        {
            _fSPAppService = fSPAppService;
        }

        [Route("Consultar")]
        public ActionResult Consulta()
        {
            return View();
        }
        // GET: Itenizacaos
        [Route("Cadastrar")]
        public ActionResult Cadastro()
        {
            ObterObrasEServicos();
            return View(new ItemServicoViewModel { CodigoItemServico=0,  ValorUnitario = Convert.ToDecimal("0,00") });
        }
        // GET: Itenizacaos
        [Route("Alterar/{id:int}")]
        public ActionResult Alteracao(int id)
        {
            return View();// _fSPAppService.ObterItenizacaoPorId(id));
        }

        #region Seção: Inclusão
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Salvar-Itenizacao")]
        public ActionResult Salvar(ItemServicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ItenizacaoViewModel = _fSPAppService.RegistrarInclusaoItemServico(model);

                if (!ItenizacaoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in ItenizacaoViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
                }
                return Json(new { erro = 0, mensagem = ItenizacaoViewModel.ValidationResult.Message });
            }
            else
                return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
        }
        #endregion

        #region Seção: Alteração
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Alterar-Itenizacao")]
        public ActionResult Alterar(ItemServicoViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var ItenizacaoViewModel = _fSPAppService.RegistrarAlteracaoItenizacao(model);

            //    if (!ItenizacaoViewModel.ValidationResult.IsValid)
            //    {
            //        foreach (var erro in ItenizacaoViewModel.ValidationResult.Erros)
            //            ModelState.AddModelError(string.Empty, erro.Message);

            //        return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
            //    }

            //    return Json(new { erro = 1, mensagem = ItenizacaoViewModel.ValidationResult.Message });
            //}
            //else
            //    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });

            return null;
        }
        #endregion

        #region Seção: Exclusão
        [HttpGet]
        [Route("Excluir-Itenizacao/{id:int}")]
        public ActionResult Excluir(int id)
        {
            //var ItenizacaoViewModel = _fSPAppService.RegistrarExclusaoItenizacao(id);
            //return Json(new { erro = 2, mensagem = "Registro excluído com sucesso." }, JsonRequestBehavior.AllowGet);

            return null;

        }
        #endregion

        [HttpGet]
        [Route("Obter-Itenizacao-Obra-Servico/{codigoObra:int}/{codigoServico:int}")]
        public string ObterItenizacaoPorCodigoObraECodigoServico(int codigoObra, int codigoServico)
        {
            return JsonConvert.SerializeObject(new { data = _fSPAppService.ObterItemServicoPorCodigoObraECodigoServico(codigoObra, codigoServico) });
        }

        [HttpGet]
        [Route("Obter-Proximo-Valor-Item/{codigoObra:int}/{codigoServico:int}")]
        public int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico)
        {
            return _fSPAppService.ObterProximoNumeroItemDoServico(codigoObra, codigoServico);
        }

        [HttpGet]
        [Route("Obter-Itenizacao-Obra-Servico-PedidoMaterial/{codigoObra:int}/{codigoServico:int}")]
        public string ObterItenizacaoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico)
        {
            return JsonConvert.SerializeObject(new { data = _fSPAppService.ObterItemServicoDaObraEDoServicoParaPedidoMaterial(codigoObra, codigoServico) });
        }

        private void ObterObrasEServicos()
        {
            var obrasViewModel = _fSPAppService.ObterTodasObras();
            ViewBag.Obras = string.Empty;
            ViewBag.Obras = new SelectList(obrasViewModel, "CodigoObra", "NomeObra", "0");

            var servicosViewModel = _fSPAppService.ObterTodosServicos();
            ViewBag.Servicos = string.Empty;
            ViewBag.Servicos = new SelectList(servicosViewModel, "CodigoServico", "DescricaoServico", "0");
        }

    }
}