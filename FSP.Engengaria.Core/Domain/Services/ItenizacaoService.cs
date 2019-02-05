using FSP.Engengaria.Core.Application.Help;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Domain.Interface.Service;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Services
{
    public class ItenizacaoService : IItenizacaoService
    {
        private readonly IItenizacaoRepository _itenizacaoRepository;
        public ItenizacaoService(IItenizacaoRepository itenizacaoRepository)
        {
            _itenizacaoRepository = itenizacaoRepository;
        }
        public void Dispose() { }

        public Itenizacao Salvar(Itenizacao itenizacao)
        {
            if (!itenizacao.IsValid())
                return itenizacao;

            itenizacao.ValidationResult.Message = Mensagem.Inclusao;
            return _itenizacaoRepository.Adicionar(itenizacao);
        }
        public Itenizacao Alterar(Itenizacao itenizacao)
        {
            if (!itenizacao.IsValid())
                return itenizacao;

            itenizacao.ValidationResult.Message = Mensagem.Alteracao;
            return _itenizacaoRepository.Atualizar(itenizacao);
        }
        public void Excluir(int id)
        {
            _itenizacaoRepository.Remover(id);
        }

        public Itenizacao ObterPorId(int id)
        {
            return _itenizacaoRepository.ObterPorId(id);
        }

        public IQueryable<Itenizacao> ObterTodosItenizacao()
        {
            return _itenizacaoRepository.ObterTodos();
        }

        public int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico)
        {
            return _itenizacaoRepository.ObterProximoNumeroItemDoServico(codigoObra, codigoServico);
        }

        public IQueryable<Itenizacao> ObterItenizacaoPorCodigoObraECodigoServico(int codigoObra, int codigoServico)
        {
            return _itenizacaoRepository.ObterItenizacaoPorCodigoObraECodigoServico(codigoObra, codigoServico);
        }
        public IQueryable<Itenizacao> ObterItenizacaoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico)
        {
            return _itenizacaoRepository.ObterItenizacaoDaObraEDoServicoParaPedidoMaterial(codigoObra, codigoServico);
        }
    }
}
