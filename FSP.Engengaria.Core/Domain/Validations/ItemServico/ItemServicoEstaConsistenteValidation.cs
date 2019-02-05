using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Specifications.Itenizacoes;

namespace FSP.Engengaria.Core.Domain.Validations.Itenizacoes
{
    public class ItemServicoEstaConsistenteValidation : Validator<ItemServico>
    {
        public ItemServicoEstaConsistenteValidation()
        {
            var itemServicoObraDiferenteZero = new ItemServicoDevePossuirUmaObraSpecification();
            var itemServicoServicoDiferenteZero = new ItemServicoDevePossuirUmServicoSpecification();
            var itemServicoValorUnitarioDiferenteZero = new ItemServicoDevePossuirValorUnitarioSpecification();

            base.Add("ItemServicoObraDiferenteZero", new Rule<ItemServico>(itemServicoObraDiferenteZero, "Seleione uma obra."));
            base.Add("ItemServicoServicoDiferenteZero", new Rule<ItemServico>(itemServicoServicoDiferenteZero, "Selecione um serviço."));
            base.Add("ItemServicoValorUnitarioDiferenteZero", new Rule<ItemServico>(itemServicoValorUnitarioDiferenteZero, "Valor unitário do item do serviço deve ser maior que zero."));
        }
    }
}
