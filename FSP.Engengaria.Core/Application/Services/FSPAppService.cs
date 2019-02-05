using AutoMapper;
using FSP.Engengaria.Core.Application.Help;
using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Service;
using FSP.Engengaria.Core.Infra.Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace FSP.Engengaria.Core.Application.Services
{
    public class FSPAppService : ApplicationServiceTransaction, IFSPAppService
    {
        private readonly IObraService _obraService;
        private readonly IServicoService _servicoService;
        private readonly IFornecedorService _fornecedorService;
        private readonly IItemServicoService _ItemServicoService;

        public void Dispose() { }

        public FSPAppService(
            IObraService obraService,
            IServicoService servicoService,
            IFornecedorService fornecedorService,
            IItemServicoService ItemServicoService,
            IUnitOfWorkTransaction uow) : base(uow)
        {
            _obraService = obraService;
            _servicoService = servicoService;
            _fornecedorService = fornecedorService;
            _ItemServicoService = ItemServicoService;
        }

        public IEnumerable<StatusObraViewModel> ObterStatusObras()
        {
            return StatusObraViewModel.ObterStatusObra();
        }

        public IEnumerable<EstadoViewModel> ObterEstados()
        {
            return EstadoViewModel.ObterEstados();
        }

        #region Seção: Obras
        public ObraViewModel RegistrarInclusaoObra(ObraViewModel obraViewModel)
        {
            var obra = Mapper.Map<Obra>(obraViewModel);

            BeginTransaction();

            var obraReturn = _obraService.Salvar(obra);

            obraViewModel = Mapper.Map<ObraViewModel>(obraReturn);
            if (!obraReturn.ValidationResult.IsValid)
                return obraViewModel;

            SaveChange();
            Commit();
            return obraViewModel;
        }
        public ObraViewModel RegistrarAlteracaoObra(ObraViewModel obraViewModel)
        {
            var obra = Mapper.Map<Obra>(obraViewModel);

            BeginTransaction();

            var obraReturn = _obraService.Alterar(obra);

            obraViewModel = Mapper.Map<ObraViewModel>(obraReturn);

            if (!obraReturn.ValidationResult.IsValid)
                return obraViewModel;

            SaveChange();
            Commit();
            return obraViewModel;
        }
        public ObraViewModel RegistrarExclusaoObra(int id)
        {
            var obraViewModel = new ObraViewModel();

            BeginTransaction();

            _obraService.Excluir(id);

            obraViewModel.ValidationResult = new DomainValidation.Validation.ValidationResult { Message = Mensagem.Exclusao };

            SaveChange();
            Commit();

            return obraViewModel;
        }
        public ObraViewModel ObterObraPorId(int id)
        {
            return Mapper.Map<ObraViewModel>(_obraService.ObterPorId(id));
        }
        public IEnumerable<ObraViewModel> ObterTodasObras()
        {
            return Mapper.Map<IEnumerable<ObraViewModel>>(_obraService.ObterTodasObras().ToList());
        }
        public IEnumerable<ObraViewModel> ObterObraPorDescricao(string nomeObra)
        {
            return Mapper.Map<IEnumerable<ObraViewModel>>(_obraService.ObterObraPorDescricao(nomeObra).ToList());
        }

        #endregion

        #region Seção: Serviço
        public ServicoViewModel RegistrarInclusaoServico(ServicoViewModel servicoViewModel)
        {
            var Servico = Mapper.Map<Servico>(servicoViewModel);

            BeginTransaction();

            var ServicoReturn = _servicoService.Salvar(Servico);

            servicoViewModel = Mapper.Map<ServicoViewModel>(ServicoReturn);
            if (!ServicoReturn.ValidationResult.IsValid)
                return servicoViewModel;

            SaveChange();
            Commit();
            return servicoViewModel;
        }
        public ServicoViewModel RegistrarAlteracaoServico(ServicoViewModel servicoViewModel)
        {
            var Servico = Mapper.Map<Servico>(servicoViewModel);

            BeginTransaction();

            var ServicoReturn = _servicoService.Alterar(Servico);

            servicoViewModel = Mapper.Map<ServicoViewModel>(ServicoReturn);

            if (!ServicoReturn.ValidationResult.IsValid)
                return servicoViewModel;

            SaveChange();
            Commit();
            return servicoViewModel;
        }
        public ServicoViewModel RegistrarExclusaoServico(int id)
        {
            var servicoViewModel = new ServicoViewModel();

            BeginTransaction();

            _servicoService.Excluir(id);

            servicoViewModel.ValidationResult = new DomainValidation.Validation.ValidationResult { Message = Mensagem.Exclusao };

            SaveChange();
            Commit();

            return servicoViewModel;
        }
        public ServicoViewModel ObterServicoPorId(int id)
        {
            return Mapper.Map<ServicoViewModel>(_servicoService.ObterPorId(id));
        }
        public IEnumerable<ServicoViewModel> ObterTodosServicos()
        {
            return Mapper.Map<IEnumerable<ServicoViewModel>>(_servicoService.ObterTodosServicos().ToList());
        }

        public IEnumerable<ServicoViewModel> ObterServicoDaObraRelacionadosNaItemServico(int codigoObra)
        {
            return Mapper.Map<IEnumerable<ServicoViewModel>>(_servicoService.ObterServicoDaObraRelacionadosNaItenizacao(codigoObra).ToList());
        }
        #endregion

        #region Seção: Fornecedor
        public FornecedorViewModel RegistrarInclusaoFornecedor(FornecedorViewModel fornecedorViewModel)
        {
            var Fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);

            BeginTransaction();

            var FornecedorReturn = _fornecedorService.Salvar(Fornecedor);

            fornecedorViewModel = Mapper.Map<FornecedorViewModel>(FornecedorReturn);
            if (!FornecedorReturn.ValidationResult.IsValid)
                return fornecedorViewModel;

            SaveChange();
            Commit();
            return fornecedorViewModel;
        }
        public FornecedorViewModel RegistrarAlteracaoFornecedor(FornecedorViewModel fornecedorViewModel)
        {
            var Fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);

            BeginTransaction();

            var FornecedorReturn = _fornecedorService.Alterar(Fornecedor);

            fornecedorViewModel = Mapper.Map<FornecedorViewModel>(FornecedorReturn);

            if (!FornecedorReturn.ValidationResult.IsValid)
                return fornecedorViewModel;

            SaveChange();
            Commit();
            return fornecedorViewModel;
        }
        public FornecedorViewModel RegistrarExclusaoFornecedor(int id)
        {
            var FornecedorViewModel = new FornecedorViewModel();

            BeginTransaction();

            _fornecedorService.Excluir(id);

            FornecedorViewModel.ValidationResult = new DomainValidation.Validation.ValidationResult { Message = Mensagem.Exclusao };

            SaveChange();
            Commit();

            return FornecedorViewModel;
        }
        public FornecedorViewModel ObterFornecedorPorId(int id)
        {
            return Mapper.Map<FornecedorViewModel>(_fornecedorService.ObterPorId(id));
        }
        public IEnumerable<FornecedorViewModel> ObterTodosFornecedors()
        {
            return Mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorService.ObterTodosFornecedors().ToList());
        }
        #endregion

        #region Item do Serviço
        public ItemServicoViewModel RegistrarInclusaoItemServico(ItemServicoViewModel ItemServicoViewModel)
        {
            var itemServico = Mapper.Map<ItemServico>(ItemServicoViewModel);

            BeginTransaction();

            ItemServico ItemServicoReturn = null;

            if (ItemServicoViewModel.CodigoItemServico == 0)
                ItemServicoReturn = _ItemServicoService.Salvar(itemServico);
            else
                ItemServicoReturn = _ItemServicoService.Alterar(itemServico);

            ItemServicoViewModel = Mapper.Map<ItemServicoViewModel>(ItemServicoReturn);
            if (!ItemServicoReturn.ValidationResult.IsValid)
                return ItemServicoViewModel;

            SaveChange();
            Commit();
            return ItemServicoViewModel;
        }

        public int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico)
        {
            return _ItemServicoService.ObterProximoNumeroItemDoServico(codigoObra, codigoServico);
        }

        public IEnumerable<ItemServicoViewModel> ObterItemServicoPorCodigoObraECodigoServico(int codigoObra, int codigoServico)
        {
            return Mapper.Map<IEnumerable<ItemServicoViewModel>>(_ItemServicoService.ObterItemServicoPorCodigoObraECodigoServico(codigoObra, codigoServico).ToList());
        }

        public IEnumerable<ItemServicoViewModel> ObterItemServicoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico)
        {
            return Mapper.Map<IEnumerable<ItemServicoViewModel>>(_ItemServicoService.ObterItemServicoDaObraEDoServicoParaPedidoMaterial(codigoObra, codigoServico).ToList());
        }
        #endregion
    }
}

