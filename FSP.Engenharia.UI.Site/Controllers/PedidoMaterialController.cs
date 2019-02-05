using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engenharia.UI.Site.Help;
using Newtonsoft.Json;
using System.Web.Mvc;
using System;

namespace FSP.Engenharia.UI.Site.Controllers
{
    [RoutePrefix("Gerenciar-PedidoMaterial")]
    public class PedidoMaterialController : Controller
    {
        private readonly IFSPAppService _fSPAppService;
        //private readonly IPedidoMaterialAppService _PedidoMaterialAppService;

        public PedidoMaterialController(IFSPAppService fSPAppService)//, IPedidoMaterialAppService PedidoMaterialAppService)
        {
            _fSPAppService = fSPAppService;
            //_PedidoMaterialAppService = PedidoMaterialAppService;
        }

        [Route("Consultar")]
        public ActionResult Consulta()
        {
            return View();
        }
        // GET: PedidoMaterials
        [Route("Cadastrar")]
        public ActionResult Cadastro()
        {
            ObterObrasEFornecedor();
            return View(new PedidoMaterialViewModel { CodigoPedido = 0, DataPedido=DateTime.Now });
        }
        // GET: PedidoMaterials
        [Route("Alterar/{id:int}")]
        public ActionResult Alteracao(int id)
        {
            return View();// _fSPAppService.ObterPedidoMaterialPorId(id));
        }

        #region Seção: Inclusão
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Salvar-PedidoMaterial")]
        public ActionResult Salvar(PedidoMaterialViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var PedidoMaterialViewModel = _PedidoMaterialAppService.RegistrarInclusaoPedidoMaterial(model);

            //    if (!PedidoMaterialViewModel.ValidationResult.IsValid)
            //    {
            //        foreach (var erro in PedidoMaterialViewModel.ValidationResult.Erros)
            //            ModelState.AddModelError(string.Empty, erro.Message);

            //        return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
            //    }
            //    return Json(new { erro = 0, mensagem = PedidoMaterialViewModel.ValidationResult.Message });
            //}
            //else
                return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
        }
        #endregion

        #region Seção: Alteração
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Alterar-PedidoMaterial")]
        public ActionResult Alterar(PedidoMaterialViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var PedidoMaterialViewModel = _fSPAppService.RegistrarAlteracaoPedidoMaterial(model);

            //    if (!PedidoMaterialViewModel.ValidationResult.IsValid)
            //    {
            //        foreach (var erro in PedidoMaterialViewModel.ValidationResult.Erros)
            //            ModelState.AddModelError(string.Empty, erro.Message);

            //        return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });
            //    }

            //    return Json(new { erro = 1, mensagem = PedidoMaterialViewModel.ValidationResult.Message });
            //}
            //else
            //    return Json(new { erro = 901, mensagem = RetornaMsgErroFormulario.RetornaMsgErro(ModelState) });

            return null;
        }
        #endregion

        #region Seção: Exclusão
        [HttpGet]
        [Route("Excluir-PedidoMaterial/{id:int}")]
        public ActionResult Excluir(int id)
        {
            //var PedidoMaterialViewModel = _fSPAppService.RegistrarExclusaoPedidoMaterial(id);
            //return Json(new { erro = 2, mensagem = "Registro excluído com sucesso." }, JsonRequestBehavior.AllowGet);

            return null;
        }
        #endregion

        [HttpGet]
        [Route("Obter-PedidoMaterial-Obra-Servico/{codigoObra:int}/{codigoServico:int}")]
        public string ObterPedidoMaterialPorCodigoObraECodigoServico(int codigoObra, int codigoServico)
        {
            return string.Empty;// JsonConvert.SerializeObject(new { data = _PedidoMaterialAppService.ObterPedidoMaterialPorCodigoObraECodigoServico(codigoObra, codigoServico) });
        }

        [HttpGet]
        [Route("Obter-Proximo-Valor-Item/{codigoObra:int}/{codigoServico:int}")]
        public int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico)
        {
            return 0;// _PedidoMaterialAppService.ObterProximoNumeroItemDoServico(codigoObra, codigoServico);
        }

        private void ObterObrasEFornecedor()
        {
            var obrasViewModel = _fSPAppService.ObterTodasObras();
            ViewBag.Obras = string.Empty;
            ViewBag.Obras = new SelectList(obrasViewModel, "CodigoObra", "NomeObra", "0");

            var fornecedoresViewModel = _fSPAppService.ObterTodosFornecedors();
            ViewBag.Fornecedores = string.Empty;
            ViewBag.Fornecedores = new SelectList(fornecedoresViewModel, "CodigoFornecedor", "RazaoSocial", "0");
        }

    }
}