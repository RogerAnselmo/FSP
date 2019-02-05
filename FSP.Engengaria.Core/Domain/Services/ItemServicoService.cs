using FSP.Engengaria.Core.Application.Help;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Domain.Interface.Service;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Services
{
    public class ItemServicoService : IItemServicoService
    {
        private readonly IItemServicoRepository _ItemServicoRepository;
        public ItemServicoService(IItemServicoRepository ItemServicoRepository)
        {
            _ItemServicoRepository = ItemServicoRepository;
        }
        public void Dispose() { }

        public ItemServico Salvar(ItemServico itemServico)
        {
            if (!itemServico.IsValid())
                return itemServico;

            itemServico.ValidationResult.Message = Mensagem.Inclusao;
            return _ItemServicoRepository.Adicionar(itemServico);
        }
        public ItemServico Alterar(ItemServico itemServico)
        {
            if (!itemServico.IsValid())
                return itemServico;

            itemServico.ValidationResult.Message = Mensagem.Alteracao;
            return _ItemServicoRepository.Atualizar(itemServico);
        }
        public void Excluir(int id)
        {
            _ItemServicoRepository.Remover(id);
        }

        public ItemServico ObterPorId(int id)
        {
            return _ItemServicoRepository.ObterPorId(id);
        }

        public IQueryable<ItemServico> ObterTodosItemServico()
        {
            return _ItemServicoRepository.ObterTodos();
        }

        public int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico)
        {
            return _ItemServicoRepository.ObterProximoNumeroItemDoServico(codigoObra, codigoServico);
        }

        public IQueryable<ItemServico> ObterItemServicoPorCodigoObraECodigoServico(int codigoObra, int codigoServico)
        {
            return _ItemServicoRepository.ObterItemServicoPorCodigoObraECodigoServico(codigoObra, codigoServico);
        }
        public IQueryable<ItemServico> ObterItemServicoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico)
        {
            return _ItemServicoRepository.ObterItemServicoDaObraEDoServicoParaPedidoMaterial(codigoObra, codigoServico);
        }
    }
}
