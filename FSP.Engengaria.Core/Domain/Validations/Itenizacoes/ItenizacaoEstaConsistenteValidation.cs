using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Specifications.Itenizacoes;

namespace FSP.Engengaria.Core.Domain.Validations.Itenizacoes
{
    public class ItenizacaoEstaConsistenteValidation : Validator<Itenizacao>
    {
        public ItenizacaoEstaConsistenteValidation()
        {
            var itenizacaoObraDiferenteZero = new ItenizacaoDevePossuirUmaObraSpecification();
            var itenizacaoServicoDiferenteZero = new ItenizacaoDevePossuirUmServicoSpecification();
            var itenizacaoValorUnitarioDiferenteZero = new ItenizacaoDevePossuirValorUnitarioSpecification();

            base.Add("itenizacaoObraDiferenteZero", new Rule<Itenizacao>(itenizacaoObraDiferenteZero, "Seleione uma obra."));
            base.Add("itenizacaoServicoDiferenteZero", new Rule<Itenizacao>(itenizacaoServicoDiferenteZero, "Selecione um serviço."));
            base.Add("itenizacaoValorUnitarioDiferenteZero", new Rule<Itenizacao>(itenizacaoValorUnitarioDiferenteZero, "Valor unitário do item do serviço deve ser maior que zero."));
        }
    }
}
