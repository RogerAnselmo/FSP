using FSP.Engengaria.Core.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace FSP.Engengaria.Core.Application.Interface
{
    public interface IFSPAppService : IDisposable
    {
        IEnumerable<StatusObraViewModel> ObterStatusObras();
        IEnumerable<EstadoViewModel> ObterEstados();

        #region Seção: Obra
        ObraViewModel RegistrarInclusaoObra(ObraViewModel obraViewModel);
        ObraViewModel RegistrarAlteracaoObra(ObraViewModel obraViewModel);
        ObraViewModel RegistrarExclusaoObra(int id);
        ObraViewModel ObterObraPorId(int id);
        IEnumerable<ObraViewModel> ObterTodasObras();
        IEnumerable<ObraViewModel> ObterObraPorDescricao(string nomeObra);

        #endregion

        #region Seção: Servico
        ServicoViewModel RegistrarInclusaoServico(ServicoViewModel servicoViewModel);
        ServicoViewModel RegistrarAlteracaoServico(ServicoViewModel servicoViewModel);
        ServicoViewModel RegistrarExclusaoServico(int id);
        ServicoViewModel ObterServicoPorId(int id);
        IEnumerable<ServicoViewModel> ObterTodosServicos();
        IEnumerable<ServicoViewModel> ObterServicoDaObraRelacionadosNaItemServico(int codigoObra);
        #endregion

        #region Seção: Fornecedor
        FornecedorViewModel RegistrarInclusaoFornecedor(FornecedorViewModel fornecedorViewModel);
        FornecedorViewModel RegistrarAlteracaoFornecedor(FornecedorViewModel fornecedorViewModel);
        FornecedorViewModel RegistrarExclusaoFornecedor(int id);
        FornecedorViewModel ObterFornecedorPorId(int id);
        IEnumerable<FornecedorViewModel> ObterTodosFornecedors();

        #endregion

        #region Seção: Itenização
        ItemServicoViewModel RegistrarInclusaoItemServico(ItemServicoViewModel itemServicoViewModel);
        int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico);
        IEnumerable<ItemServicoViewModel> ObterItemServicoPorCodigoObraECodigoServico(int codigoObra, int codigoServico);
        IEnumerable<ItemServicoViewModel> ObterItemServicoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico);
        #endregion
    }
}
