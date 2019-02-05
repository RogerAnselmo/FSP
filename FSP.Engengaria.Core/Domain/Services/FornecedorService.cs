using FSP.Engengaria.Core.Application.Help;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Domain.Interface.Service;
using FSP.Engengaria.Core.Domain.Validations.Servicos;
using System;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }
        public void Dispose() { }

        public Fornecedor Salvar(Fornecedor fornecedor)
        {
            if (!fornecedor.IsValid())
                return fornecedor;

            fornecedor.ValidationResult = new FornecedorAptoParaCadastroValidation(_fornecedorRepository).Validate(fornecedor);

            if (!fornecedor.ValidationResult.IsValid)
            {
                return fornecedor;
            }

            fornecedor.ValidationResult.Message = Mensagem.Inclusao;
            return _fornecedorRepository.Adicionar(fornecedor);
        }
        public Fornecedor Alterar(Fornecedor fornecedor)
        {
            if (!fornecedor.IsValid())
                return fornecedor;

            fornecedor.ValidationResult.Message = Mensagem.Alteracao;
            return _fornecedorRepository.Atualizar(fornecedor);
        }
        public void Excluir(int id)
        {
            _fornecedorRepository.Remover(id);
        }

        public Fornecedor ObterPorId(int id)
        {
            return _fornecedorRepository.ObterPorId(id);
        }

        public IQueryable<Fornecedor> ObterTodosFornecedors()
        {
            return _fornecedorRepository.ObterTodos();
        }

        
    }
}
