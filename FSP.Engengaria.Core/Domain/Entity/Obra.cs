using System;
using System.Collections.Generic;
using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Validations.Obras;

namespace FSP.Engengaria.Core.Domain.Entity
{
    public class Obra
    {

        public int CodigoObra { get; set; }
        public string DescricaoObjeto { get; set; }
        public string NomeObra { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public virtual ICollection<ItemServico> ItensServicos { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ObraEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public Obra()
        {
            ItensServicos = new List<ItemServico>();
        }
    }
}
