using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Specifications.Servicos;

namespace FSP.Engengaria.Core.Domain.Validations.Servicos
{
    public class ServicoEstaConsistenteValidation : Validator<Servico>
    {
        public ServicoEstaConsistenteValidation()
        {
            var servicoPercentualMaiorQueZero = new ServicoDeveTerUmPercentualSpecification();
            var servicoValorMaiorQueZero = new ServicoDeveTerUmValorSpecification();

            base.Add("servicoPercentualMaiorQueZero", new Rule<Servico>(servicoPercentualMaiorQueZero, "Percentual do serviço deve ser maior que zero."));
            base.Add("servicoValorMaiorQueZero", new Rule<Servico>(servicoValorMaiorQueZero, "Valor do serviço deve ser maior que zero."));
        }
    }
}
