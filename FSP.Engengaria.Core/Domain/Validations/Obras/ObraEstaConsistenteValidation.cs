using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Specifications.Obras;

namespace FSP.Engengaria.Core.Domain.Validations.Obras
{
    public class ObraEstaConsistenteValidation : Validator<Obra>
    {
        public ObraEstaConsistenteValidation()
        {
            var objetoSemDescricao = new ObraDeveTerUmObjetoSpecification();
            var obraSemNome = new ObraDeveTerUmObjetoSpecification();
            var obraSemStatus = new ObraDeveTerUmaSituacaoSpecification();
            var obraSemUF = new ObraDeveTerUmaUFSpecification();

            base.Add("objetoSemDescricao", new Rule<Obra>(objetoSemDescricao, "Objeto da obra não pode ser branco."));
            base.Add("obraSemNome", new Rule<Obra>(obraSemNome, "Nome da obra não pode ser branco."));
            base.Add("obraSemStatus", new Rule<Obra>(obraSemStatus, "Situação da obra não pode ser branco."));
            base.Add("obraSemUF", new Rule<Obra>(obraSemUF, "Obra deve ter uma UF"));
        }
    }
}
