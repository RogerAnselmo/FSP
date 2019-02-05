using FSP.Engengaria.Core.Application.Help;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Domain.Interface.Service;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        public ServicoService(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }
        public void Dispose() { }

        public Servico Salvar(Servico servico)
        {
            if (!servico.IsValid())
                return servico;

            servico.ValidationResult.Message = Mensagem.Inclusao;
            return _servicoRepository.Adicionar(servico);
        }
        public Servico Alterar(Servico servico)
        {
            if (!servico.IsValid())
                return servico;

            servico.ValidationResult.Message = Mensagem.Alteracao;
            return _servicoRepository.Atualizar(servico);
        }
        public void Excluir(int id)
        {
            _servicoRepository.Remover(id);
        }

        public Servico ObterPorId(int id)
        {
            return _servicoRepository.ObterPorId(id);
        }

        public IQueryable<Servico> ObterTodosServicos()
        {
            return _servicoRepository.ObterTodos();
        }

        //public IQueryable<Servico> ObterServicoPorDescricao(string nomeServico)
        //{
        //    return _ServicoRepository.ObterServicoPorDescricao(nomeServico);
        //}

        public IQueryable<Servico> ObterServicoDaObraRelacionadosNaItenizacao(int codigoObra)
        {
            return _servicoRepository.ObterServicoDaObraRelacionadosNaItenizacao(codigoObra);
        }

    }
}
