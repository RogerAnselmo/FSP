using FSP.Engengaria.Core.Application.Help;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Domain.Interface.Service;
using System;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Services
{
    public class ObraService : IObraService
    {
        private readonly IObraRepository _obraRepository;
        public ObraService(IObraRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }
        public void Dispose() { }

        public Obra Salvar(Obra obra)
        {
            if (!obra.IsValid())
                return obra;

            obra.ValidationResult.Message = Mensagem.Inclusao;
            return _obraRepository.Adicionar(obra);
        }
        public Obra Alterar(Obra obra)
        {
            if (!obra.IsValid())
                return obra;

            obra.ValidationResult.Message = Mensagem.Alteracao;
            return _obraRepository.Atualizar(obra);
        }
        public void Excluir(int id)
        {
            _obraRepository.Remover(id);
        }

        public Obra ObterPorId(int id)
        {
            return _obraRepository.ObterPorId(id);
        }

        public IQueryable<Obra> ObterTodasObras()
        {
            return _obraRepository.ObterTodos();
        }

        public IQueryable<Obra> ObterObraPorDescricao(string nomeObra)
        {
            return _obraRepository.ObterObraPorDescricao(nomeObra);
        }
    }
}
