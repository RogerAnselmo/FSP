using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engenharia.UI.Site.Help;
using Newtonsoft.Json;
using System.Web.Mvc;
using System;

namespace FSP.Engenharia.UI.Site.Controllers
{
    [RoutePrefix("Gerenciar-ItemServico")]
    public class ItemServicoController : Controller
    {
        private readonly IFSPAppService _fSPAppService;

        public ItemServicoController(IFSPAppService fSPAppService)
        {
            _fSPAppService = fSPAppService;
        }

        [Route("Consultar")]
        public ActionResult Consulta()
        {
            return View();
        }
        // GET: ItemServicos
        [Route("Cadastrar")]
        public ActionResult Cadastro()
        {
            ObterObrasEServicos();
            return View(new ItemServicoViewModel { CodigoItemServico=0,  ValorUnitario = Convert.ToDecimal("0,00") });
        }
        // GET: ItemServicos
        [Route("Alterar/{id:int}")]
        public ActionResult Alteracao(int id)
        {
            return View();// _fSPAppService.ObterItemServicoPorId(id));
        }

        #region Seção: Inclusão
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Salvar-ItemServico")]
        public ActionResult Salvar(ItemServicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ItemServicoViewModel = _fSPAppService.RegistrarInclusaoItemServico(model);

                if (!ItemServicoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in ItemServicoViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
                }
                return Json(new { erro = 0, mensagem = ItemServicoViewModel.ValidationResult.Message });
            }
            else
                return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
        }
        #endregion

        #region Seção: Alteração
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Alterar-ItemServico")]
        public ActionResult Alterar(ItemServicoViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var ItemServicoViewModel = _fSPAppService.RegistrarAlteracaoItemServico(model);

            //    if (!ItemServicoViewModel.ValidationResult.IsValid)
            //    {
            //        foreach (var erro in ItemServicoViewModel.ValidationResult.Erros)
            //            ModelState.AddModelError(string.Empty, erro.Message);

            //        return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
            //    }

            //    return Json(new { erro = 1, mensagem = ItemServicoViewModel.ValidationResult.Message });
            //}
            //else
            //    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });

            return null;
        }
        #endregion

        #region Seção: Exclusão
        [HttpGet]
        [Route("Excluir-ItemServico/{id:int}")]
        public ActionResult Excluir(int id)
        {
            //var ItemServicoViewModel = _fSPAppService.RegistrarExclusaoItemServico(id);
            //return Json(new { erro = 2, mensagem = "Registro excluído com sucesso." }, JsonRequestBehavior.AllowGet);

            return null;

        }
        #endregion

        [HttpGet]
        [Route("Obter-ItemServico/{codigoObra:int}/{codigoServico:int}")]
        public string ObterItemServicoPorCodigoObraECodigoServico(int codigoObra, int codigoServico)
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
        [Route("Obter-ItemServico-Obra-Servico-PedidoMaterial/{codigoObra:int}/{codigoServico:int}")]
        public string ObterItemServicoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico)
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